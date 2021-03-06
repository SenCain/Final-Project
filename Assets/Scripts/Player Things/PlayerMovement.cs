﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject Player1;
    public Camera playerCamera;
    public float speed;
    public float camSpeed;
    Rigidbody rb;
    Vector3 cameraMove;
    public float maxSpeed;

    float camRestraint;
    

    // Use this for initialization
    void Start () {

        Player1 = this.gameObject;
        rb = Player1.GetComponent<Rigidbody>();
        camRestraint = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //  rb.velocity = movement * speed;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector3 force = new Vector3();
        if (movement.x > 0) force += Player1.transform.right * speed;
        else if (movement.x < 0) force += -Player1.transform.right * speed;

        if (movement.y > 0) force += Player1.transform.forward * speed;
        else if (movement.y < 0) force += -Player1.transform.forward * speed;

        force = Vector3.ClampMagnitude(force + rb.velocity, maxSpeed);

        //Jumping!  Make sure to change / add a limit to how far up you can jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            force.y += 200.0f;
            
        }

        rb.AddForce(force);

       
    }


    void Update()
    {
        //50 max on the camera rotation 310 max 
        float camMoveVertical = Input.GetAxis("Mouse X");
        float camMoveHorizontal = Input.GetAxis("Mouse Y");

        //playerCamera.transform.Rotate(-camMoveVertical * camSpeed, camMoveHorizontal * camSpeed, 0.0f);

        //Rotation left and right
        Player1.transform.Rotate(0.0f, camMoveVertical * camSpeed, 0.0f);

        //camera move up and down 
       
       // if (playerCamera.transform.rotation.x >= 0 && playerCamera.transform.rotation.x <= 50)
       // {
       
        

        //      Work on camera Restraints!!!!

       // if(playerCamera.transform.rotation.x >= 0.0f && playerCamera.transform.rotation.x < 50 || playerCamera.transform.rotation.x > 310 && playerCamera.transform.rotation.x <= 360.0f || playerCamera.transform.rotation.x >= 0 && playerCamera.transform.rotation.x < 3 || playerCamera.transform.rotation.x <= 360 && playerCamera.transform.rotation.x > 357)
            playerCamera.transform.Rotate(-camMoveHorizontal * camSpeed, 0.0f, 0.0f);
        Debug.Log(Input.GetAxisRaw("Mouse Y"));
      //  }
    }
    
}
