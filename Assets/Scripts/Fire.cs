using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    private CandyMovement candy;

    public GameObject candyPrefab;

    GameObject CandyInstance;
    void Start () {
		
	}
	
	void Update () {
        if ( Input.GetButtonDown ("Fire1") )
        {
            
           CandyInstance = Instantiate(candyPrefab, this.transform.position, Quaternion.identity) ;

            //CandyInstance.AddForce((Vector2.up * candy.candySpeed) * Time.deltaTime
            Destroy(CandyInstance, 2f);

        }
        
    }
}
