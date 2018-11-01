using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {


    public GameObject candyPrefab;

    GameObject CandyInstance; private Transform playerPos;
    void Start () {
        playerPos = GetComponent<Transform>();
	}
	
	void Update () {
        if ( Input.GetMouseButtonDown (0) )
        {

            CandyInstance = Instantiate(candyPrefab, playerPos.position, Quaternion.identity) ;

            //CandyInstance.transform.Translate(Vector3.up);
            Destroy(CandyInstance, 2f);


        }
        
    }
}
//if (((Input.GetButtonDown("Fire1")) && Input.GetKeyDown(KeyCode.A)))
//            {
//                transform.Translate((transform.right* candySpeed * Time.deltaTime));
//            }
//            if ((Input.GetKeyDown(KeyCode.D) && (Input.GetButtonDown("Fire1"))))
//            {
//                transform.Translate((transform.up* candySpeed * Time.deltaTime));
//            }