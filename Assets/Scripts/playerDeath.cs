using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author Brennan J.C Kersey
 * Script Purpose: To allow the player to die
 */
public class playerDeath : MonoBehaviour {
    private GameObject playerDie;
    //public TimerScript timemanager;
	// Use this for initialization
	void Start () {
       // timemanager = GameObject.FindGameObjectWithTag("time manager").GetComponent<TimerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider col)
    {
        //print("Hit!");
        if (col.CompareTag("Player"))
        {
            print("I'm dead goodbye cruel world");
            playerDie = col.gameObject;
            Destroy(playerDie);
            //timemanager.endGame();

        }

        return;

    


    }
}
