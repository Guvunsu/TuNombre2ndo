using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{

    private MovementPlayer movPlayer;
    private Animator animator;
    public Timer timerLevel;

    public List<Sprite> heartsSprite;//jalarlso desde la carpeta de sprites
    public List<GameObject> heartsUI;//aqui jalo desde mis objetos de mi jerarquia

    [SerializeField]
    private float healthTimer = 0.5f;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private int layerint;
    [SerializeField]
    private Transform respawnPoints;
    [SerializeField]
    private GameObject[] hearts;

    int timerPoints;

    public bool isAlive = true;
    public string sceneManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {//o ponle .tag ==
           timerPoints = (int)timerLevel.ReturnTimer();
            Time.timeScale = 0f;
            PoinstManager.Instance.addPoints(timerPoints);
            GameManager.Instance.IsGameWin = true;
            Debug.Log("Ganaste");

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isAlive = true;
            PoinstManager.Instance.addPoints(timerPoints);
            Destroy(collision.gameObject);
            Debug.Log("Lo Toque");
        }
        else
        {
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerint)
        {
            sprite.color = Color.white;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {//tal vez ni siquiera se llama asi el mio 
            if (healthTimer > 0)
            {
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0 && lives >= 0)
            {
                lives--;
                lifeHeart();
                sprite.color = Color.blue;
                if (lives > 0)
                {
                    RestartPoint();
                }
                else if (lives < 0)
                {
                    isAlive = false;
                    PlayerLose();
                }
                healthTimer = 0.5f;
            }
        }
    }
    public void lifeHeart()
    {
        //tengo 3 corazones , implemente un array para bajarme un corazon por cada daño que me hagan
        if (lives < 4)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("hurt");
            
        }
        else if (lives < 3)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("hurt");
        }
        else if (lives < 2)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("hurt");
        }
        else if (lives < 1)
        {
            Destroy(hearts[3].gameObject);
            animator.Play("hurt");
        }

    }
    //public void arraylifeDamage()
    //{
    //    lives--;
    //    lifeHeart();
    //}
    public void PlayerLose()
    {
        movPlayer.DisableMovement();
        GameManager.Instance.IsGameLose = true;

    }

    public void RestartPoint()
    {
        gameObject.transform.position = respawnPoints.position;
        sprite.color = Color.green;
        lives = 3;

        movPlayer.EnableMovement();
    }
    //private void changeHeartsSprite()
    //{
    //    switch (lives)
    //    {
    //        case 5:
    //            heartsUI[0].gameObject.GetComponent<Image>().sprite = heartsSprite[1];
    //            break;

    //        case 4:
    //            heartsUI[0].gameObject.GetComponent<Image>().sprite = heartsSprite[2];
    //            break;

    //        case 3:
    //            heartsUI[1].gameObject.GetComponent<Image>().sprite = heartsSprite[1];
    //            break;

    //        case 2:
    //            heartsUI[1].gameObject.GetComponent<Image>().sprite = heartsSprite[2];
    //            break;

    //        case 1:
    //            heartsUI[2].gameObject.GetComponent<Image>().sprite = heartsSprite[1];
    //            break;

    //        case 0:
    //            heartsUI[2].gameObject.GetComponent<Image>().sprite = heartsSprite[2];
    //            break;

    //        default:
    //            break;
    //    }
    //}
    //public void LoadScene() {
    //    UnityEngine.SceneManager.instance.LoadScene("Menu", LoadSceneMode.Additive);
    //}

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<MovementPlayer>();//MovementPlayer=
        lives = hearts.Length;
    }
    private void Awake()
    {
        GameManager.Instance.IsGameLose = false;
        GameManager.Instance.isGameWin = false;
    }


    void Update()
    {

    }
}
