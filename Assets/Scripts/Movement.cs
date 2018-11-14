using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movespeed;
    private Rigidbody mybody;
	// Use this for initialization
	void Start () {
        mybody=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        float movementHorizontal = Input.GetAxisRaw("Horizontal")*movespeed;
        float movementVertical = Input.GetAxisRaw("Vertical")*movespeed;

       // print(movementHorizontal);
        //print(movementVertical);

        //transform.Translate(movementHorizontal * Time.deltaTime * movespeed, 0f, movementVertical * Time.deltaTime * movespeed);

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        mybody.AddForce(movement);
    }
}
