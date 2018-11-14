using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseTester : MonoBehaviour {

    private LevelManager manager;
    
    // Use this for initialization
	void Start () {
		manager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.Pause();
        }
	}

}
