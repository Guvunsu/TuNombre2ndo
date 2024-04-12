
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    public static SceneManager instance;

    private void Awake() {
        {
            if (instance == null) {
                //==null todas las tipo clase gameobject de Unity, tu puedes referenciar
                instance = this;
                // busca y selecciona scenemanager
                DontDestroyOnLoad(gameObject);
                //no destruye un permanente objetivo gameobject cuando carga la escena
            } else {
                Destroy(gameObject);
            }
        }
    }

    public void LoadScene(string sceneName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}







//public void NextLevel() {
//    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
//}

