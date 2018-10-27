using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    float smoothing = 5;

    private Vector3 offset;
    void Start () {
        offset = transform.position - player.transform.position;
		
	}
	

	void LateUpdate () {
        transform.position = player.transform.position + offset;

       transform.position = Vector3.Lerp(transform.position, transform.position, smoothing * Time.deltaTime);

    }

    
}
