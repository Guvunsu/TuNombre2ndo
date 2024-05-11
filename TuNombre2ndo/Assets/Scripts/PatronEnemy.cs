using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PatronEnemy : MonoBehaviour {

    //https://www.youtube.com/watch?v=RuvfOl8HhhM
    // practicamente copie casi todo el codigo 

    public float dt;

    private Vector2 Point;
    private Vector3 localScale;

    [SerializeField] private SpriteRenderer spritEnemy;
    [SerializeField] private GameObject PointA;
    [SerializeField] private GameObject PointB;
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Transform currentPoint;


    public float speed = 2.0f;

    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
        currentPoint = PointA.transform;
        
    }

    // Update is called once per frame
    void Update() {
        moveEnemy();
    }
   
    private void moveEnemy() {
        Point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform) {
            Rb.velocity = new Vector2(speed, 0);
        } else
            Rb.velocity = new Vector2(-speed, 0);

        if (Vector2.Distance(transform.position, currentPoint.position) < -0.5f && currentPoint == PointB.transform) {
            flip();
            currentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f && currentPoint == PointA.transform) {
            flip();
            currentPoint = PointB.transform;
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
