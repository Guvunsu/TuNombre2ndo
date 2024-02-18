using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformeBehaviour : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    public float timer;
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {

            timer = 0f;
            effector2D.rotationalOffset = 0f;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (timer <= 0)
            {
                effector2D.rotationalOffset = 100f;
                timer = 0.5f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
