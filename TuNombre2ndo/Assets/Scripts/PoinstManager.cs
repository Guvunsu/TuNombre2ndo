using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

        // esto deberi estar en el objeto de la puerta para ganar con la llave 

        if (collision.gameObject.CompareTag("Key")) {

            Debug.Log("Lo Hemos Logrado");
            //agregar una escena de victoria
        }

        // agrega puntos y destruyo enemigos y monedas 

        points++;
        Destroy(collision.gameObject);
    }
    public void addPoints(int pointsToAdd) {
        points++;
        points += pointsToAdd;
        Debug.Log(points);
    }
    void Start() {
        points = 0;
    }

    //accedo desde el texto de mi TMPro de mi canvas de mis puntos y lo actualiza con addPoints 

    void Update() {
        textoUGUI.text = points.ToString();
    }

}
