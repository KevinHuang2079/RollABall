using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY : MonoBehaviour
{
    public float speed = 5.0f;
    public float stickyDuration = 10.0f;
    public bool isSticky;
    public GameObject player;
    protected Material playerMaterial;
    public WallDetector wallDetector;
    private Vector3 stickyPosition;
    public Renderer playerRenderer;
    
    
    private Rigidbody playerRigidbody;

    public void Start()
    {
        Renderer playerRenderer = player.GetComponent<Renderer>();
        isSticky = false;
        playerRigidbody = GetComponent<Rigidbody>();
    }
    public void itsStickyTime()
    {
        playerRenderer.material.color = Color.blue;
        isSticky = true;
        
    }
    

    public void stickLeftMovement()
    {
        Vector3 v3Velocity = playerRigidbody. velocity;
        if (v3Velocity.x < 1)
        {
            //print("stickLeft()");
            Vector3 currentPosition = player.transform.position;
            float moveForward = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, moveVertical, moveForward); // Reverse horizontal movement for sticking to the left wall
            player.transform.position = currentPosition + movement * speed * Time.deltaTime;
        }
    }
    
    public void stickRightMovement()
    {
        Vector3 v3Velocity = playerRigidbody. velocity;
        if (v3Velocity.x < 1)
        {
            //print("stickRight()");
            Vector3 currentPosition = player.transform.position;
            float moveForward = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, moveVertical, -moveForward); // Reverse horizontal movement for sticking to the left wall
            player.transform.position = currentPosition + movement * speed * Time.deltaTime;
        }
    }
    public void stickForwardMovement()
    {
        Vector3 v3Velocity = playerRigidbody. velocity;
        if (v3Velocity.z < 1)
        {
            //print("stickForward()");
            Vector3 currentPosition = player.transform.position;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f); // Reverse horizontal movement for sticking to the left wall
            player.transform.position = currentPosition + movement * speed * Time.deltaTime;
        }
    }
    public void stickBackMovement()
    {
        Vector3 v3Velocity = playerRigidbody. velocity;
        if (v3Velocity.z < 1)
        {
            //print("stickBack()");
            Vector3 currentPosition = player.transform.position;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(-moveHorizontal, moveVertical, 0.0f); // Reverse horizontal movement for sticking to the left wall
            player.transform.position = currentPosition + movement * speed * Time.deltaTime;
        }
    }
    
   
}