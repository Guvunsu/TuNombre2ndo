using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformeBehaviour : MonoBehaviour {

    private PlatformEffector2D effector2D;

    public float timer;

    void Start() {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    void Update() {

        //supuestamente si estoy en una plataforma y este no tiene un tilemap abajo que me impida bajar 
        //si apreto flecha a abajo o S , baja mi personaje ya que rota el efecto de la plataforma 

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {

            timer = 0f;
            effector2D.rotationalOffset = 0f;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {

            // se requiere un timer para activar y desactivar esta funcion anterior cuando apreto la felcha abajo o S 

            if (timer <= 0) {
                effector2D.rotationalOffset = 100f;
                timer = 0.5f;
            } else {
                timer -= Time.deltaTime;
            }
        }
    }
}
