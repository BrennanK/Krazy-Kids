using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    float smoothing = 0.5f;

    private Vector3 offset;
    void Start () {

        offset = transform.position - player.transform.position;
		
	}
	

	void LateUpdate () {

        Method();
        

    }
   public void Method()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);

        transform.position = Vector3.Lerp(transform.position, transform.position, smoothing * Time.deltaTime);

    }

}
