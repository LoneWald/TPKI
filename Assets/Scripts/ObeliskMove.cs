using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObeliskMove : MonoBehaviour
{
    public float speed = 1;
    public float time = 0;
    private float timer = 0;
    public float pause = 0;
    private int count = 0;

    void Start()
    {
        timer = 0;
        count = 0;
        pause /= Time.deltaTime;
    }
    void FixedUpdate()
    {
        if(pause > 0)
        {
            pause--;
        }
        else
        {
            if(timer < time)
            {
                count++;
                timer = count * Time.deltaTime;
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            else
            {
                timer = 0;
                speed = -speed;
                count = 0;
            }
        }
    }
}
