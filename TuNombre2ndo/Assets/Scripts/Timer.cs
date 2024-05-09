
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerTotal = 90;
    [SerializeField] private TextMeshProUGUI textoUGUI;

    //variables para que funcione el timer 
    private bool timerUp = false;

    //variables primitivas (para el GUI)
    int minutes;
    int seconds;
    string timerString;


    void Awake()
    {

    }
    void Update()
    {
        // timer();
        if (timerTotal > 0 && !timerUp)
        {
            timerTotal -= Time.deltaTime;
        }
        else timerUp = true;
        timerTotal = 0;
        if (timerUp)
        {
            GameManager.Instance.IsGameLose = true;
        }

        textoUGUI.text = timeFormat();//pedir ayuda en ambois caso por overflow en stack 
    }

    public bool TimerUp
    {
        // regresa un valor que esta afuera del script
        get => timerUp;
        //establece un nuevo valor en una variable
        set => timerUp = value;
    }

    private string timeFormat()
    {
        minutes = Mathf.FloorToInt(timerTotal / 60f);
        seconds = Mathf.FloorToInt(timerTotal - minutes * 60f);

        timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        return timerString;
    }

    //timer
    //public void timer() {
    //    if (timerTotal > 0 && !timerUp) {
    //        timerTotal -= Time.deltaTime;
    //    } else timerUp = true;

    //    textTime.text = timeFormat();
    //}

    //para resetear el timer
    public float ReturnTimer()
    {
        return timerTotal;
    }
    //para colocar o no el timer 

}

//interfaz del timer, configuracion,y parametros de este  
//private void OnGUI() {
//    //FloorToInt me regresa unnnumero floatante pequeño a uno entero similar o igual

//    GUI.skin.label.fontSize = 50;//tamano del formato de los minutos y segundos
//    GUI.contentColor = Color.cyan;//color de este
//    GUI.Label(new Rect(10, 10, 250, 100), timerString);//creacion de un rectangulo
//}