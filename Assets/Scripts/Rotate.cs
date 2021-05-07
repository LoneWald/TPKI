using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int speed_X = 30, speed_Y = 0, speed_Z = 0;
    public float time = 0;
    private float past = 0;
    void FixedUpdate()
    {
        if (past < time)
            past += Time.deltaTime;
        else
        transform.Rotate(new Vector3(speed_X, speed_Y, speed_Z) * Time.deltaTime);
    }
}
