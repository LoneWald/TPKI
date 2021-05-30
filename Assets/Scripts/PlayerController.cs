using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public float speed = 1f;
    private Rigidbody rb;

    public Vector3 startPos = new Vector3(0, 0, 0);
    public Joystick joystick;
    public bool collisiya;
    
    private int count;
    public Vector3 movement;
    public Vector3 movement_t;
    private float _ang;
    private Vector3 rotatedVector;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hoverHorizontal = joystick.Horizontal;
        float hoverVertcal =  joystick.Vertical;
        movement_t = Vector3.ProjectOnPlane(cam.GetComponent<CameraRotateAround>().napr, new Vector3(0, 1, 0)).normalized;
        movement = new Vector3(hoverHorizontal, 0, hoverVertcal);
        if (movement != Vector3.zero)
            _ang = Vector3.SignedAngle(movement_t, movement, Vector3. up) + Vector3.SignedAngle(Vector3.forward, movement_t, Vector3. up);
        else _ang = 0;
        if (movement != Vector3.zero)
        {
            rotatedVector = Quaternion.Euler(0,_ang,0) * movement_t;
            rb.AddForce(rotatedVector * speed * movement.magnitude);
        }

        if(Input.GetButton("Cancel"))
            SceneManager.LoadScene(0);
        if (Input.GetKey("r")){
            transform.position = startPos;
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
         }
        if (collisiya == true)
        {
            count++;
            if (count > 3){
            collisiya = false; 
            count = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "res")
        {
            transform.position = startPos;
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
            collisiya = true;
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(6);
        }
    }
}

    