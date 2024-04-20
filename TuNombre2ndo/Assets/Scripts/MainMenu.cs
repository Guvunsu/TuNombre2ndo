using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public void startGame() {
        GameManager.Instance.sceneSwitch("Gameplay");
    }

    public void exitGame() {
        Application.Quit();
    }
    // ponerlo en menu , 
    //poner en exit changescene 
    //poner play again reset()
    //hacer prefabs el canvas lose en el menu para que cargue 
}
