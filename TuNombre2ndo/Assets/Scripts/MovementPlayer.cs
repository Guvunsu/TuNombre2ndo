using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variables generales del script

    private float MoveSpeed = 700;
    public float JumpForce;
    private float JumpMin;
    public float jumpMax;
    int Jumps = 2;

    //cosas de FixedUpdate Fisicas 

    private Vector2 Move;
    private float dt;
    private float HiInput;
    [SerializeField]
    RaycastHit2D raycastHit;


    // llamados de libreria 

    [SerializeField]
    private SpriteRenderer Sprite;
    private Rigidbody2D rbPlayer;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Physics2D personaje;
    private LayerMask capaTileMap;


    void Start()
    {
        // getcomponents abajo

        Sprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        JumpMin = jumpMax;
    }
    private void Movimiento()
    {

        // sprint paramovimeinto normal y acelerado 

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
        if ( TocoSuelo())
        {
            JumpMin = jumpMax;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && JumpMin > 0)
        {
            JumpMin--;
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 0f);
            rbPlayer.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && Jumps < 2)
        //{
        //    rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, JumpForce);
        //    Jumps++;
        //    animator.SetBool("Jumping", true);
        //    Debug.Log("funciono ");
        //}
    }

    private bool TocoSuelo() // min 8:10 hasta el min 16:10 www.youtube.com/watch?v=2wbrHTfgvbs

    // uso la variable booleana para que me entregue un verdadero o falso si esta en el suelo 
    // uso el Raycast para que cuando salte lance un rayo laser imaginario de punto a punto para medir si este esta tocando el suelo u pared 
    // asi el mono recibe la informacion de que es ese objeto y que esta colisionando con este 

    // uso el Boxcast para un punto de origen , que llama el Boxcollider , que bounds nos devuelven los limites de la colision y a su vez a la variable center
    //el tamaño de mi caja osea el BoxCast , es la que me debera entregar un nuevo vector con los limites de su x e y del colisionador 
    // como nos debe de dar un angulo esta Boxcast , es recta por eso es 0f 
    // despues es la direccion osea el suelo y este valor es vector2 . down 
    // despues la distancia de esta que es su valor de 0.2f 
    //al final nos pide la capa que sera utilizado esta funcion , que sera el nombre de mi tilemap
    {
        //cree una variuable llamda capa , en el inspector se la asigne a esta variable y luego la llamo la RaycastHitbox2d 
        //si mi mono a colisionado con un objeto guardara una referencia de ese gameobject en el collider 
        // en el caso que no haya colisionado con nada , esa misma variable tendra un valor nulo 
        // como el Boxcast solo puede interactuar con el suelo , la comparacion sera el return verdadero 
        // si el valor de lo colisionado es nula , es poeque no a colionado con nada , osea si no esta en el suelo , esta en el aire y volvera el valor a true
        // y viceversa 


        raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaTileMap);
        return raycastHit.collider != null;
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
        TocoSuelo();

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
