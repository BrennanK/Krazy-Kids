using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fatKidDeath : MonoBehaviour {
    public SpawnManager manager; // reference to spawn manger in game to track number of enemies in game 
    public int hitpoints; // number of hits for enemy to die
                          // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("spawn manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Candy")  // if bullet collides with enemy hit box
        {
            
            GameObject bullet = col.gameObject;
            if (hitpoints == 1) // destroy if 1 hitpoint left else reduce remaining hit points
            {
                Destroy(this.gameObject);
                manager.lowerCount();
            }
            else
            {
                hitpoints--;
            }
            Destroy(bullet); // destroys bullets so they can't hit more than 1 enemy
        }
        return;
    }
}
