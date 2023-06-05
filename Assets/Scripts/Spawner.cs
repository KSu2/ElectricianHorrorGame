using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;

    //need to have some variable for the bounds of where the items can spawn in
    public int minZ;
    public int maxZ;

    public int minX;
    public int maxX;

    public int spawnLimit;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        //spawn spawnLimit number of items in the world with random positions
        for (int i = 0; i < spawnLimit; i++)
        {
            float randX = Random.Range(minX, maxX + 1);
            float randZ = Random.Range(minZ, maxZ + 1);
            //generate a random position within the bounds
            Vector3 spawnPosition = new Vector3(randX, 5, randZ);
            Spawn(spawnPosition, Quaternion.identity);
        }
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        // a copy of the game object which will be spawned randomly in the world
        GameObject clone = Instantiate(itemToSpawn, position, rotation);
    }
}
