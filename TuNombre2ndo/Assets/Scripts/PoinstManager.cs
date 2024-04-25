using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoinstManager : MonoBehaviour {
    //Mi singleton
    public static PoinstManager Instance;

    [SerializeField] private TextMeshProUGUI textoUGUI;

    int points;
    // codigo para mi singleton 
    private void Awake() {
        //si hay una Instancia de mis pointsmanager , destruyeme si no lo soy 
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        //si la instancia es nula , yo soy la instancia 
        else {
            Instance = this;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Lo Hemos Logrado");
        points++;
        Destroy(collision.gameObject);//tal vez le ponga mejor el (this)
    }
    public void addPoints(int pointsToAdd) {
        points++;
        points += pointsToAdd;
        Debug.Log(points);
    }
    void Start() {
        points = 0;
    }

    // Update is called once per frame
    void Update() {
        textoUGUI.text = ToString();
    }
}
