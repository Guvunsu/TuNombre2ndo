using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float healthTimer = 0.5f;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private int healthPóints = 100;
    [SerializeField]
    private int layerint;
    [SerializeField]
    private Transform respawnPoints;
    public bool isAlive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Win"))
        {
            Debug.Log("Ganaste");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerint)
        {
            if (healthTimer > 0)
            {
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0 && isAlive)
            {
                healthPóints--;
                if (healthPóints < -0)
                {
                    isAlive = false;
                    Debug.Log("perdiste");
                }
                healthTimer = 0.5f;
            }
        }
    }

    public void PlayerLose()
    {
        sprite.color = Color.cyan;
    }

    public void RestartPoint()
    {
        gameObject.transform.position = respawnPoints.position;
        sprite.color = Color.green;
        healthPóints = 10;
        isAlive = true;
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
