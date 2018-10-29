using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMovement : MonoBehaviour {

    public float candySpeed;
	void Start () {
		
	}
	
	void Update () {

        transform.Translate((Vector3.up * candySpeed )* Time.deltaTime);
	}
}
