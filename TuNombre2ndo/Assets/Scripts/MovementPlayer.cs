using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {
    // variables generales del script

    private float MoveSpeed = 700;
    public float JumpForce;
    int Jumps = 0;
    private bool isGrounded;
    public float gravity;
    //bool TocoSuelo;

    //cosas de FixedUpdate Fisicas 

    private Vector2 Move;
    private float dt;
    private float HiInput;


    // llamados de libreria 

    [SerializeField]
    private SpriteRenderer Sprite;
    private Rigidbody2D rbPlayer;
    private Animator animator;
    private BoxCollider2D boxCollider;



    void Start() {
        // getcomponents abajo

        Sprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

    }
    private void Movimiento() {

        // sprint paramovimeinto normal y acelerado 

        if (Input.GetKey(KeyCode.LeftShift)) {
            MoveSpeed = 1400;
            animator.SetBool("Runing", true);
        } else {
            MoveSpeed = 700;
            animator.SetBool("Runing", false);
        }


        // voltear sprite

        if (Move.x > 0) {
            Sprite.flipX = false;
            animator.SetBool("Walking", true);

        }//le quite el if else a la siguiente 
        if (Move.x < 0) {
            Sprite.flipX = true;
            animator.SetBool("Walking", true);
        } else animator.SetBool("IDLE", true);

    }
    private void Jump() {
        // salto

        if (Input.GetKeyDown(KeyCode.Space) && Jumps < 2 /*&& isGrounded*/) {

            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, JumpForce);
            Jumps++;
            animator.SetBool("Jumping", true);
            // animator.SetBool("isGrounded", isGrounded);//agrege esto graias por Hugo 
            animator.SetBool("fall", true);
            // if (!TocoSuelo)
            // {
            //animator.SetBool("Jumping", false);
            //animator.SetBool("fall", false);
            // }

        }


    }

    private void FixedUpdate() {

        // definicion de varialbles

        HiInput = Input.GetAxisRaw("Horizontal");

        dt = Time.deltaTime;
        Move = new Vector2(HiInput * MoveSpeed * dt, rbPlayer.velocity.y);
        rbPlayer.velocity = Move;


    }

    void Update() {

        Movimiento();
        Jump();
        Physics2D.gravity = gravity * Vector2.up;

    }

    public void DisableMovement() {
        MoveSpeed = 0;
        JumpForce = 0;
    }
    public void EnableMovement() {

    }

    void OnCollisionEnter2D(Collision2D collision) {

        //    // resetear salto

        if (collision.collider.CompareTag("Tilemap")) {

            //        // esto es para que el salto solo se resetee cuando toca el suelo, y no una pared, techo etc...
            //        // Aqu� se utiliza un condicional para verificar el �ngulo entre la normal de la colisi�n y el vector hacia arriba (Vector2.up).
            //        // La normal es un vector perpendicular a la superficie de colisi�n. 
            //        // Este condicional verifica si el �ngulo entre la normal y el vector hacia arriba es menor a 45 grados.
            //        // conseguido de stack overflow de usuario "Voidsay"

            if (Vector2.Angle(collision.GetContact(0).normal, Vector2.up) < 45) {
                Jumps = 0;
                animator.SetBool("Jumping", false);

            }

        }


    }
}
