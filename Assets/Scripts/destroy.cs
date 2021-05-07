using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class destroy : MonoBehaviour
{
    private float timer = 0;
    private float time = 1;
    private bool col = false;
    private GameObject ssilkaNaObject;
    void Start()
    {
        ssilkaNaObject = GameObject.Find("modelka");
        timer = 0f;
        time = 0.5f;
        col = false;
    }

    void FixedUpdate()
    {
        if (col == true)
        {
            timer += Time.deltaTime;
            if(timer > time)
            {
                offPlatform();
                col = false;
                timer = 0f;
            }
        }
        if (Input.GetKey("r")){
            onPlatform();
        }
        if(ssilkaNaObject.GetComponent<PlayerController>().collisiya == true)
        {
            onPlatform();
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            col = true;
        }
    }
    void offPlatform () 
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        
    }
    void onPlatform () 
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}

