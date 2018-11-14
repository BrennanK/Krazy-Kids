using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline1 : MonoBehaviour {
    private mazescoreboard mazeManager;
	// Use this for initialization
	void Start ()
    {
        mazeManager = GameObject.FindGameObjectWithTag("time manager").GetComponent<mazescoreboard>();
	}

    // Update is called once per frame
    public void OnTriggerEnter(Collider col)
    {
        print("finish line crossed by "+ col.gameObject.name);
        if(col.gameObject.tag=="Player")
        {
            mazeManager.endGame();
            mazeManager.finishedMaze();
        }
    }
}
