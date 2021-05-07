using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 newPosition;
    public float time = 0;
    private int count = 0;

    private void Start() {
        newPosition.y += 0.55f;
    }
    private void OnTriggerEnter(Collider other) {
        //other.transform.position = newPosition;
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "player")
        {
            count++;
        }
        if(count*Time.deltaTime>=time)
        {
            other.transform.position = newPosition;
        }
    }

    private void OnTriggerExit(Collider other) {
        count = 0;
    }
}
