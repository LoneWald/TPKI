using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move_Platform : MonoBehaviour
{
    public float X = 1;
    public float Y = 0;
    public float Z = 0;
    public int timeForMoving = 2;
    public float delay = 0;
    public bool direction_of_moving = true;
    private double speed = 0;
    private double range = 0;
    private double delay_time_up = 0;
    private double countDist = 0;
    private int direction = 0;
    void Start()
    {
        range = Math.Sqrt(X * X + Y * Y + Z * Z);
        delay_time_up = 0;
        countDist = 0;
        speed = range / timeForMoving;
        if(direction_of_moving)
            direction = 1;
        else
            direction = -1;
    }
    void FixedUpdate()
    {
        if(delay_time_up < delay)
        {
            delay_time_up += 1 * Time.deltaTime;
        }
        else
        {
            if(Math.Abs(countDist)<=range-0.001f)
            {
                countDist += (1 * Time.deltaTime) * speed;
                transform.Translate(new Vector3(X * direction / timeForMoving * Time.deltaTime, Y * direction / timeForMoving * Time.deltaTime, Z * direction / timeForMoving * Time.deltaTime));
            }
            else
            {
                direction = -direction;
                delay_time_up = 0;
                countDist = 0;
                speed = -speed;
            }
            
        }
        /*if (delay_time_up < delay)
            delay_time_up += Time.deltaTime;
        else
        {
            delay_time_down -= Time.deltaTime;
            transform.Translate(new Vector3(X / speed * Time.deltaTime, Y / speed * Time.deltaTime, Z / speed * Time.deltaTime));
            Max++;
            
            if (Max >=Math.Abs(speed)*50)
            {
                speed = -speed;
                Max = 0;
            }
            if (delay_time_down <= 0)
            {
                delay_time_up = 0;
                delay_time_down = Math.Abs(speed) - Time.deltaTime;
            }
            
        }
        */
    }
}
