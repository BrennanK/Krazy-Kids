using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerMovement : MonoBehaviour {

    public float speed = 10f;
   

    Vector3 input;

    void Start () {

        transform.position = new Vector3(0, 0.56f, -8.64f);

        

    }
	
	
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;
        // transform.Translate(moveAmount);
        LimitPlayerMovement();
        
    }
    void LimitPlayerMovement()
    {

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -3.75f, 3.135f);
        transform.position = pos;
    }
   
}
