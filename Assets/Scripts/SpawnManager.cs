using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    private int numberofEnemies;
    public int enemyLimit;
    public GameObject [] prefabForEnemy;
    private GameObject enemySpawned;
    public List<Transform> locationsOfSpawners;
    private Transform spawnpoint;
    //public float secondsBetweenSpawn;
	// Use this for initialization
	void Start ()
    {
        numberofEnemies = 0;
        Spawn(locationsOfSpawners[0],1);
        Spawn(locationsOfSpawners[1],1);
        Spawn(locationsOfSpawners[2],1);
        Spawn(locationsOfSpawners[3],1);
        numberofEnemies = 4;
    }

    // Update is called once per frame

    
    void Update ()
    {
        spawnpoint = locationsOfSpawners[Random.Range(0, locationsOfSpawners.Count)]; //Random.Range(0, 4)
        if (numberofEnemies != enemyLimit && spawnpoint!=null)
        {
            spawnpoint = locationsOfSpawners[Random.Range(0, locationsOfSpawners.Count)]; //Random.Range(0, 4)
            Spawn(spawnpoint,0);
            numberofEnemies++;
        }
       // print(numberofEnemies);
	}

    public void Spawn(Transform spawnlocation,int i)
    {
        enemySpawned = Instantiate(prefabForEnemy[i], spawnlocation.position, spawnlocation.rotation);
        //Instantiate()
        
        
    }

    public void lowerCount()
    {
        numberofEnemies -= 1;
    }

    public void removeSpawnPoint(Transform point)
    {
        locationsOfSpawners.TrimExcess();
        locationsOfSpawners.Remove(locationsOfSpawners.Find(x => x.position == point.position));
        locationsOfSpawners.TrimExcess();
    }

    public void addSpawnPoint(Transform point)
    {
        locationsOfSpawners.Add(point);
    }
}
