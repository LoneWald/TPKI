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
    public GameObject CheckPointObeliskPrefab;
    public float speed = 1f;
    private Rigidbody rb;

    public Vector3 startPos = new Vector3(0, 0, 0);
    //public Joystick joystick;
    public bool collisiya;
    private Vector3 currentPos;
    private int count;
    public Vector3 movement;
    public Vector3 movement_t;
    private float _ang;
    private Vector3 rotatedVector;
    private Stack<Vector3> checkPoints = new Stack<Vector3>();
    private GameObject CheckPointObelisk;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPos = startPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SaveCheckPoint();

        if (Input.GetKeyDown(KeyCode.Q))
            DeleteCheckPoint();
            
        if (Input.GetKeyDown(KeyCode.R))
            ReturnToPosition();
    }
    void FixedUpdate()
    {

        Movement();

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Menu");

        
        if (collisiya == true)
        {
            count++;
            if (count > 3)
            {
                collisiya = false;
                count = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "res")
        {
            transform.position = currentPos;
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
            collisiya = true;
        }
    }

    void Movement()
    {
        float hoverHorizontal = Input.GetAxis("Horizontal");
        float hoverVertcal = Input.GetAxis("Vertical");
        movement_t = Vector3.ProjectOnPlane(cam.GetComponent<CameraRotateAround>().napr, new Vector3(0, 1, 0)).normalized;
        movement = new Vector3(hoverHorizontal, 0, hoverVertcal);
        if (movement != Vector3.zero)
            _ang = Vector3.SignedAngle(movement_t, movement, Vector3.up) + Vector3.SignedAngle(Vector3.forward, movement_t, Vector3.up);
        else _ang = 0;
        if (movement != Vector3.zero)
        {
            rotatedVector = Quaternion.Euler(0, _ang, 0) * movement_t;
            rb.AddForce(rotatedVector * speed * movement.magnitude);
        }

        /*  for stick
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
        */
    }

    void SaveCheckPoint()
    {
        checkPoints.Push(currentPos);
        if(CheckPointObelisk != null)
            GameObject.Destroy(CheckPointObelisk);
        currentPos = transform.position;
        CheckPointObelisk = Instantiate(CheckPointObeliskPrefab, currentPos, new Quaternion(0, 0, 0, 0));
    }
    void DeleteCheckPoint()
    {
        if(CheckPointObelisk != null)
            GameObject.Destroy(CheckPointObelisk);
        currentPos = checkPoints.Pop();
        CheckPointObelisk = Instantiate(CheckPointObeliskPrefab, currentPos, new Quaternion(0, 0, 0, 0));
        ReturnToPosition();
    }

    void ReturnToPosition()
    {
        transform.position = currentPos;
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
    }
}

