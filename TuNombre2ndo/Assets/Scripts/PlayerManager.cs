using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{

    private GameManager gameManager;
    private MovementPlayer movPlayer;
    public GameObject losePanel;
    public GameObject winPanel;
    // private Animator animator;
    public Timer timerLevel;
    public AudioSource audio;
    public LayerMask ZonaDeMuerte;

    public bool isAlive = true;
    public bool losePanelIsOpen;
    public string sceneManager;

    bool key = false;
    int timerPoints;

    public List<AudioClip> clips;
    public List<Sprite> heartsSprite;
    public List<GameObject> heartsUI;

    [SerializeField] private float healthTimer = 0.1f;
    [SerializeField] private float lives = 3f;
    [SerializeField] private float damagePerSecond = 10f;
    [SerializeField] private int layerint;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform respawnPoints;
    [SerializeField] private GameObject[] hearts;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        // el OncollisionTrigger me sirve para tomar mis objetos del mapa 

        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
            key = true;
            audio.clip = clips[0];
            audio.Play();
        }
        if (collision.gameObject.CompareTag("Win") && key)
        {

            // si llevo la llave donde el objeto tenga el tag de Win podre ganar el nivel 

            playerWin();
            timerPoints = (int)timerLevel.ReturnTimer();
            Time.timeScale = 0f;
            PoinstManager.Instance.addPoints(timerPoints);
            GameManager.Instance.IsGameWin = true;
            Debug.Log("Ganaste");

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

        // me baja vida el layer Zona de Muerte y con un tiempo determinado 

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ZonaDeMuerte"))
        {
            lives -= damagePerSecond * Time.deltaTime;
            lifeHeart();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Door") && )
        //{

        //}
        //esto sirve que si colisiono con mi enemigo me baja vida llamando funciones que estan mas abajo en este script

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (healthTimer > 0)
            {
                isAlive = true;
                arraylifeDamage();
                PoinstManager.Instance.addPoints(timerPoints);
                Destroy(collision.gameObject);
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0 && lives <= 0)
            {
                arraylifeDamage();
                sprite.color = Color.blue;
                if (lives <= 0)
                {
                    RestartPoint();
                }
                else if (lives < 0)
                {
                    isAlive = false;
                    playerLose();
                }
                healthTimer = 0.1f;
            }
        }
    }
    public void lifeHeart()
    {

        //tengo 3 corazones , implemente un array para bajarme un corazon por cada daño que me hagan

        if (lives < 4)
        {
            hearts[2].gameObject.SetActive(false);
            //animator.Play("hurt");
        }
        if (lives < 3)
        {
            hearts[1].gameObject.SetActive(false);
            //animator.Play("hurt");
        }
        if (lives < 2)
        {
            hearts[0].gameObject.SetActive(false);
            //animator.Play("hurt");
        }
        if (lives < 1)
        {
            losePanel.SetActive(true);
            //animator.Play("Dead");
        }

    }
    public void arraylifeDamage()
    {

        //para bajar vida 

        lives--;
        lifeHeart();
    }

    public void playerWin()
    {

        winPanel.SetActive(true);
        GameManager.Instance.IsGameWin = true;

    }

    public void playerLose()
    {

        //me bloquea movimiento del jugador si muere 

        GameManager.Instance.IsGameLose = true;
        movPlayer.DisableMovement();

    }

    public void RestartPoint()
    {

        // se reinicia los puntos cuando reincarno y me activa el movimeinto cuandomaparezco de nuevo 

        gameObject.transform.position = respawnPoints.position;
        sprite.color = Color.green;
        lives = 3;

        movPlayer.EnableMovement();
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<MovementPlayer>();
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
