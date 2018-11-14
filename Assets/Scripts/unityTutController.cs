using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityTutController : MonoBehaviour {
    public float movespeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;
	// Use this for initialization
	void Start ()
    {
        mainCamera= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movespeed;

        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        //transform.Translate(movementHorizontal * Time.deltaTime * movespeed, 0f, movementVertical * Time.deltaTime * movespeed);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin,pointToLook,Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
	}

     void FixedUpdate()
    {
        //myRigidbody.velocity = moveVelocity;
    }
}
