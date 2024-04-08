using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager Instance;
    public PlayerManager Player;
    public string sceneManager;
    public GameObject losePanel;

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
        public void changeScene() {
            SceneManager.LoadScene(scenemanager);
        }
    }
}
