using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PatronEnemy : MonoBehaviour {

    //https://www.youtube.com/watch?v=RuvfOl8HhhM

    public float dt;

    private Vector2 movEnemy;
    private Vector2 Point;
    private Vector3 localScale;

    [SerializeField]
    private SpriteRenderer spritEnemy;
    [SerializeField]
    private GameObject PointA;
    [SerializeField]
    private GameObject PointB;
    [SerializeField]
    private Rigidbody2D Rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform currentPoint;


    public float speed = 2.0f;

    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = PointB.transform;
        currentPoint = PointA.transform;
        animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update() {
        moveEnemy();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        dt = Time.deltaTime;
        //if (movEnemy )
        if (collision.gameObject.CompareTag("Player")) {
            // GameObject.Instantiate.GetComponent<PoinstManager>();
            gameObject.GetComponent<PoinstManager>();//a ver si funciona esto 
            Debug.Log("El jugador si me esta tocando");
        }
        {
            if (collision.gameObject.CompareTag("Tilemap")) {
                movEnemy = new Vector2(speed, 1);
                moveEnemy();
                flip();

            }


        }
    }
    private void moveEnemy() {
        Point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform) {
            Rb.velocity = new Vector2(speed, 0);
        } else
            Rb.velocity = new Vector2(-speed, 0);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform) {
            flip();
            currentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f && currentPoint == PointA.transform) {
            flip();
            currentPoint = PointB.transform;
        }
        if (movEnemy.x > 0) {
            spritEnemy.flipX = false;
            animator.SetBool("Walking", true);

        } else if (movEnemy.x < 0) {
            spritEnemy.flipX = true;
            animator.SetBool("Walking", true);
        }

    }
    private void flip() {
        localScale = transform.localScale;
        localScale.x = -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.2f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.2f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

}
