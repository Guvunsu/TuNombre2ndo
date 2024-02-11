using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variables generales del script

    private float MoveSpeed = 700;
    [SerializeField]
    private SpriteRenderer Sprite;
    private Rigidbody2D rbPlayer;
    private float JumpForce = 6;
    int Jumps = 2;
    private Animator animator;


    //cosas de FixedUpdate Fisicas 

    private Vector2 Move;
    private float dt;
    private float HiInput;


    //cosas de animacion 
    [SerializeField]
    private Animator animators;

    void Start()
    {
        // getcomponents abajo

        Sprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {

        // definicion de varialbles

        HiInput = Input.GetAxisRaw("Horizontal");

       // animator.SetFloat("Walking", Mathf.Abs ( HiInput)); 
        //// visto en min 11:36 https://www.youtube.com/watch?v=hkaysu1Z-N8&list=PLPV2KyIb3jR6TFcFuzI2bB7TMNIIBpKMQ&index=13


        dt = Time.deltaTime;
        Move = new Vector2(HiInput * MoveSpeed * dt, rbPlayer.velocity.y);
        rbPlayer.velocity = Move;


    }

    void Update()
    {

        Movimiento();
        Jump();

    }

    private void Movimiento()
    {

        // sprint

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 1400;
            animator.SetBool("Runing", true);
        }
        else
        {
            MoveSpeed = 700;
            animator.SetBool("Runing", false);
        }


        // voltear sprite

        if (Move.x > 0)
        {
            Sprite.flipX = false;
            animator.SetBool("Walking", true);

        }
        else if (Move.x < 0)
        {
            Sprite.flipX = true;
            animator.SetBool("Walking", true);
        }
        else animator.SetBool("IDLE", false);

    }
    private void Jump()
    {
        // salto

        if (Input.GetKeyDown(KeyCode.Space) && Jumps < 2)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, JumpForce);
            Jumps++;
            animator.SetBool("Jumping", true);
            Debug.Log("funciono ");
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    // resetear salto

    //    if (collision.collider.CompareTag("Floor"))
    //    {

    //        // esto es para que el salto solo se resetee cuando toca el suelo, y no una pared, techo etc...
    //        // Aquí se utiliza un condicional para verificar el ángulo entre la normal de la colisión y el vector hacia arriba (Vector2.up).
    //        // La normal es un vector perpendicular a la superficie de colisión. 
    //        // Este condicional verifica si el ángulo entre la normal y el vector hacia arriba es menor a 45 grados.
    //        // conseguido de stack overflow de usuario "Voidsay"

    //        if (Vector2.Angle(collision.GetContact(0).normal, Vector2.up) < 45)
    //        {
    //            Jumps = 0;
    //            animator.SetBool("Jumping", false);

    //        }

    //    }


    //}
}
