using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    private CandyMovement candy;
    public Rigidbody candyPrefab;
    

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody CandyInstance;
           CandyInstance = Instantiate(candyPrefab, this.transform.position, Quaternion.identity);
            //CandyInstance.AddForce((Vector2.up * candy.candySpeed) * Time.deltaTime);

        }
    }
}
