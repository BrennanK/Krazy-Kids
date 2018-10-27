using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public Rigidbody candyPrefab;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody CandyInstance;
           CandyInstance = Instantiate(candyPrefab, this.transform.position, Quaternion.identity);
            CandyInstance.AddForce(Vector3.forward);

        }
    }
}
