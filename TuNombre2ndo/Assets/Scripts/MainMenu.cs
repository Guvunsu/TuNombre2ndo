using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void startGame() {
        GameManager.Instance.sceneSwitch("Gameplay");
    }

    public void exitGame() {
        Application.Quit();
    }

}
