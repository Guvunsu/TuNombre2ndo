using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager Player;
    void Start()
    {

    }


    void Update()
    {
        if (!Player.isAlive)
        {
            Debug.Log("GameOver");
        }
    }
}
