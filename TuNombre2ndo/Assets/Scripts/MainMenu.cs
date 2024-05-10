using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public void startGame() {

        // cambia de escena de Menu a Gameplay cuando se lo solicito 

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
