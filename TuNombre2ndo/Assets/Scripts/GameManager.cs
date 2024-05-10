using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;// aguregue este para el load
using UnityEngine;

public class GameManager : MonoBehaviour {


    [SerializeField] private AudioSource audio;
    public static GameManager Instance;
    public GameObject losePanel;

    public bool losePanelIsOpen = true;
    public bool winPanelIsOpen = true;

    public bool isGameWin = false;
    private bool isGameLose = false;


    public bool IsGameWin {
        get => isGameWin;
        set => isGameWin = value;
    }

    public bool IsGameLose {
        get => IsGameLose;
        set => isGameLose = value;


    }
    private void Awake() {

        //sirve para que no me destrruyan las escenas de los juegos y los llama

        if (Instance == null) {
            Instance = this;
            music();
        } else {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    void Start() {
        losePanelIsOpen = false;
        isGameWin = false;
    }


    void Update() {

        //esta sirve para activar la escena de muerte/derrota cuando hayas perdido

        if (isGameLose && !losePanelIsOpen) {
            Instantiate(losePanel);
            losePanelIsOpen = true;
            gameObject.SetActive(true);
            Debug.Log("GameOver");
        }
        //if (Player == null) {
        //    Player = FindObjectOfType<PlayerManager>();
        //}
    }

    public void sceneSwitch(string sceneName) {

        //esto me hace cambiar de UI´s 

        losePanelIsOpen = false;
        winPanelIsOpen = false;
        isGameWin = false;
        isGameLose = false;
        SceneManager.LoadScene(sceneName);
    }

    private void music() {
        audio.Play();
    }

}

