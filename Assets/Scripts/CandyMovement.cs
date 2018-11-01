using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMovement : MonoBehaviour {

    public float candySpeed ;

    private Vector2 target;

	void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, candySpeed * Time.deltaTime);

    }



}
