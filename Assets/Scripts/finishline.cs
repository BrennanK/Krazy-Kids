using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour {
    private mazescoreboard mazeManager;
	// Use this for initialization
	void Start ()
    {
        mazeManager = GameObject.FindGameObjectWithTag("time manger").GetComponent<mazescoreboard>();
	}

    // Update is called once per frame
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player")
        {
            mazeManager.endGame();
        }
    }
}
