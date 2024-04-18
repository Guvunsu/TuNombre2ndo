using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject panel;

    public bool gameIsPaused;

    void Start() {

    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameIsPaused = !gameIsPaused;
            pauseGame();
        }
    }
    public void pauseGame() {
        if (gameIsPaused) {
            Time.timeScale = 0f;
            panel.SetActive(true);
        } else {
            resumeGame();
        }
    }
    public void resumeGame() {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Reset() {
        Time.timeScale = 1;
        GameManager.Instance.sceneSwitch("Gameplay");
    }

    public void returnMainMenu() {
        Time.timeScale = 1;
        GameManager.Instance.sceneSwitch("Menu");
    }

    public void exitGame() {
        Application.Quit();
    }
}
