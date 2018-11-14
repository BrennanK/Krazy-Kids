using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altFiring : MonoBehaviour {

    public GameObject candy;
    public Transform firepoint;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GameObject newCandy=Instantiate(candy, firepoint.position, firepoint.rotation);
            //newCandy.transform.Translate(Vector3.forward * speed*Time.deltaTime);
            Destroy(newCandy, 2f);
        }
	}
}
