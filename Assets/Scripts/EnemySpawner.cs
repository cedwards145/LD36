using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenSpawns = 10;
    public float lastSpawn;

    // Use this for initialization
    void Start()
    {
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawn + timeBetweenSpawns)
            spawn();
    }

    void spawn()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        lastSpawn = Time.time;
    }
}
