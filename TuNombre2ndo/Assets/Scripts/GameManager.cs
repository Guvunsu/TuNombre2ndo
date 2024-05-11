using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;// aguregue este para el load
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //[SerializeField] private AudioSource audio;
    public static GameManager Instance;

    public bool losePanelIsOpen = false;
    public bool winPanelIsOpen = false;

    public bool isGameWin = false;
    private bool isGameLose = false;

    void Start()
    {
        losePanelIsOpen = false;
        isGameWin = false;
    }

    public bool IsGameWin
    {
        get => isGameWin;
        set => isGameWin = value;
    }

    public bool IsGameLose
    {
        get => IsGameLose;
        set => isGameLose = value;


    }
    private void Awake()
    {

        //sirve para que no me destrruyan las escenas de los juegos y los llama

        if (Instance == null)
        {
            Instance = this;
           // music();
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    public void sceneSwitch(string sceneName)
    {

        //esto me hace cambiar de UI´s 

        losePanelIsOpen = false;
        winPanelIsOpen = false;
        isGameWin = false;
        isGameLose = false;
        SceneManager.LoadScene(sceneName);
    }

    public void activateLosePanel()
    {
        //esta sirve para activar la escena de muerte/derrota cuando hayas perdido

        losePanelIsOpen = true;
    }

    public void activateWinPanel()
    {
        winPanelIsOpen = true;
    }

    //private void music()
    //{
    //    audio.Play();
    //}

    void Update()
    {
    }

}

