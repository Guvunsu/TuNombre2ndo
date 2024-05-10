using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject panel;
    
    public bool gameIsPaused;

    public void Reset() {
        
    }
    void Start(){

    }

    void Update() {

        //para pausar el juego con un input 

        if (Input.GetKeyDown(KeyCode.Escape)/* && GameManager.Instance.isGameWin && GameManager.Instance.IsGameLose == false*/)
        {
            gameIsPaused = !gameIsPaused;
            pauseGame();
        }
    }
    public void pauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
           
        }
        else
        {
            resumeGame();
        }
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        GameManager.Instance.sceneSwitch("Gameplay");
    }

    public void returnMainMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.sceneSwitch("Menu");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
