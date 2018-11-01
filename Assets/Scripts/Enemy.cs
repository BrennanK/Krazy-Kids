using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject clone;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	
	void Start () {

  
    }
	
	void Update () {

        Spawn();   

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("candy")) {
            Destroy(this.transform);
        }

    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        clone= Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        GameObject parent = new GameObject("enemyHolder");

        Destroy(this.clone, 3);
        

    }
}
