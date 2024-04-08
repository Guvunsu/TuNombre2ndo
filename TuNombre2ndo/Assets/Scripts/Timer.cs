
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Timer : MonoBehaviour {

    //variables para que funcione el timer 
    private float timerTotal = 90f;
    private bool timerUp = false;

    //variables primitivas (para el GUI)
    int minutes;
    int seconds;
    string timerString;
    void Start() {

    }

    void Update() {
        timer();
    }
    //interfaz del timer, configuracion,y parametros de este  
    private void OnGUI() {
        //FloorToInt me regresa unnnumero floatante peque�o a uno entero similar o igual
        minutes = Mathf.FloorToInt(timerTotal / 60f);
        seconds = Mathf.FloorToInt(timerTotal - minutes * 60f);

        timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        GUI.skin.label.fontSize = 50;//tamano del formato de los minutos y segundos
        GUI.contentColor = Color.cyan;//color de este
        GUI.Label(new Rect(10, 10, 250, 100), timerString);//creacion de un rectangulo
    }
    //timer
    public void timer() {
        if (timerTotal > 0 && !timerUp) {
            timerTotal -= Time.deltaTime;
        } else timerUp = true;
    }
    //para resetear el timer
    public float ReturnTimer() {
        return timerTotal;
    }
    //para colocar o no el timer 
    public bool TimerUp {
        // regresa un valor que esta afuera del script
        get => TimerUp;
        //establece un nuevo valor en una variable
        set => TimerUp = value;
    }
}
