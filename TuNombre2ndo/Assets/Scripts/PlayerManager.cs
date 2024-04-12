using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    private MovementPlayer movPlayer;
    [SerializeField]
    private float healthTimer = 0.5f;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private int healthPoints = 100;
    [SerializeField]
    private int layerint;
    [SerializeField]
    private Transform respawnPoints;
    public bool isAlive = true;
    private int lives = 3;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == ("Win")) {
            Debug.Log("Ganaste");

        }
        if (collision.gameObject.tag == ("Enemy")) {
            isAlive = true;
            Destroy(collision.gameObject);
            Debug.Log("Lo Toque");
        } else {
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == layerint) {
            sprite.color = Color.white;
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.layer == layerint) {
            if (healthTimer > 0) {
                healthTimer -= Time.deltaTime;
            } else if (healthTimer <= 0 && healthPoints >= 0) {
                healthPoints--;
                sprite.color = Color.blue;
                if (healthPoints > 0) {
                    RestartPoint();
                } else if (lives < 0) {
                    isAlive = false;
                    PlayerLose();
                }
                healthTimer = 0.5f;
            }
        }
    }

    public void PlayerLose() {
        movPlayer.DisableMovement();

    }

    public void RestartPoint() {
        gameObject.transform.position = respawnPoints.position;
        sprite.color = Color.green;
        healthPoints = 10;

        movPlayer.EnableMovement();
    }
    //public void LoadScene() {
    // UnityEngine.SceneManager.instance.LoadScene("Menu", LoadSceneMode.Additive);
    //}
    void Start() {

    }


    void Update() {

    }
}
