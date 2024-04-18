using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;// aguregue este para el load
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager Instance;

    public PlayerManager Player;
    public GameObject losePanel;

    public string sceneManager;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
    void Start() {

    }


    void Update() {
        if (!Player.isAlive) {
            gameObject.SetActive(true);
            Debug.Log("GameOver");
        }
        if (Player == null) {
            Player = FindObjectOfType<PlayerManager>();
        }
    }

    public void sceneSwitch() { // tal vez ponerle un string sceneName, al igual que abajo
        SceneManager.instance.LoadScene(sceneManager);
    }



}

