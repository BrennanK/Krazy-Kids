using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour {
    private SpawnManager manager;
	// Use this for initialization
	void Start ()
    {
		manager= GameObject.FindGameObjectWithTag("spawn manager").GetComponent<SpawnManager>();
    }
	

    public void OnTriggerEnter(Collider col)
    {
        print("I'm on top of the spawner");
        print("This is the object inside my spawner"+col.gameObject.name);
        if (col.gameObject.tag == "Player")  // if bullet collides with enemy hit box
        {
            print(col.gameObject.name);
            manager.removeSpawnPoint(this.transform);
        }
        return;
    }

    public void OnTriggerExit(Collider col)
    {
        print("I'm exiting the spawner");
        //print(col.gameObject.name);
        if (col.gameObject.tag == "Player")  // if bullet collides with enemy hit box
        {
            print(col.gameObject.name);
            manager.addSpawnPoint(this.transform);
        }
        return;
    }
}
