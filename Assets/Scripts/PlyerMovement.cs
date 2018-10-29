using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerMovement : MonoBehaviour {

    public float speed = 10f;
   

    Vector3 input;

    void Start () {

        transform.position = new Vector3(0, 0, -0.1f); 

        
    }
	
	
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;
        // transform.Translate(moveAmount);
      //  LimitPlayerMovement();
        
    }
    //void LimitPlayerMovement()
    //{

    //    Vector3 pos = transform.position;
    //    pos.x = Mathf.Clamp(-14.0f, -3.75f, 0);
    //    transform.position = pos;
    //}
   
}
