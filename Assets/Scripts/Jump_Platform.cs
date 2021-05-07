using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Platform : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 0, 0);
    private float timer = 0;
    private float time = 1;
    private bool col = false;
    private GameObject ssilkaNaObject;
    void Start()
    {
        ssilkaNaObject = GameObject.Find("modelka");
        timer = 0f;
        time = 0.3f;
        col = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (col == true)
        {
            timer += Time.deltaTime;
            if(timer > time)
            {
                Jump();
                col = false;
                timer = 0f;
            }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            col = true;
            ssilkaNaObject = other.gameObject;
        }
    }
    void Jump()
    {
        
        ssilkaNaObject.GetComponent<Rigidbody>().AddForce(direction);
    }
}
