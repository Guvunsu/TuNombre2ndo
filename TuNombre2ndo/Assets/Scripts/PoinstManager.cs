using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinstManager : MonoBehaviour {
    //Mi singleton
    public static PoinstManager Instance;

    int points = 0;
    

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

    public void addPoints(int pointsToAdd) {
        points=points+1;
        points += pointsToAdd;
        Debug.Log(points);
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
