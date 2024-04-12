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
    private int healthPoints = 3;
    [SerializeField]
    private int layerint;
    [SerializeField]
    private Transform respawnPoints;
    public bool isAlive = true;

    private Animator animator;
    [SerializeField]
    private GameObject[] hearts;
    public string sceneManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Win")) {//o ponle .tag ==
            Debug.Log("Ganaste");

        }
        if (collision.gameObject.CompareTag("Enemy")) {
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
        if (collision.gameObject.CompareTag("Enemy")) {//tal vez ni siquiera se llama asi el mio 
            if (healthTimer > 0) {
                healthTimer -= Time.deltaTime;
            } else if (healthTimer <= 0 && healthPoints >= 0) {
                healthPoints--;
                sprite.color = Color.blue;
                if (healthPoints > 0) {
                    RestartPoint();
                } else if (healthPoints < 0) {
                    isAlive = false;
                    PlayerLose();
                }
                healthTimer = 0.5f;
            }
        }
    }
    public void lifeHeart() {
        //tengo 3 corazones , implemente un array para bajarme un corazon por cada daño que me hagan
        if (healthPoints < 1) {
            Destroy(hearts[0].gameObject);
            animator.Play("hurt");
            SceneManager.instance.LoadScene(sceneManager);
        } else if (healthPoints < 2) {
            Destroy(hearts[1].gameObject);
            animator.Play("hurt");
        } else if (healthPoints < 3) {
            Destroy(hearts[2].gameObject);
            animator.Play("hurt");
        }
    }
    public void arraylifeDamage() {
        healthPoints--;
        lifeHeart();
    }
    public void PlayerLose() {
        movPlayer.DisableMovement();

    }

    public void RestartPoint() {
        gameObject.transform.position = respawnPoints.position;
        sprite.color = Color.green;
        healthPoints = 3;

        movPlayer.EnableMovement();
    }
    //public void LoadScene() {
    //    UnityEngine.SceneManager.instance.LoadScene("Menu", LoadSceneMode.Additive);
    //}
    void Start() {
        healthPoints = hearts.Length;
    }


    void Update() {

    }
}
