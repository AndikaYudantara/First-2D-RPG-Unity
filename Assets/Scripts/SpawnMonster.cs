using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public SpawnSkeleton skeletonObj;
    public float minSpawnRadius = 5;
    public float maxSpawnRadius = 10;
    public float spawnRate = 5; 
    
    Transform player;
    Vector2 minSpawnPoint;
    Vector2 maxSpawnPoint;
    Vector2 randomSpawnPosition;

    float minSpawnDistance;
    float maxSpawnDistance;
    float randomSpawnDistance;
    float spawnRadius;
    float prevSpawnTime;


    private void Start()
    {
        minSpawnPoint = new Vector2(minSpawnRadius, minSpawnRadius);
        maxSpawnPoint = new Vector2(maxSpawnRadius, maxSpawnRadius);   
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        minSpawnDistance = Vector2.Distance(player.position, minSpawnPoint);
        maxSpawnDistance = Vector2.Distance(player.position, maxSpawnPoint);
        
        if (Time.time-prevSpawnTime > spawnRate)
        {
            Spawn();
            prevSpawnTime = Time.time;
        }
        
        
    }

    void Spawn()
    {
        randomSpawnPosition.x = Random.Range(minSpawnDistance, maxSpawnDistance);
        randomSpawnPosition.y = Random.Range(minSpawnDistance, maxSpawnDistance);
        Instantiate(skeletonObj);
    }
}
