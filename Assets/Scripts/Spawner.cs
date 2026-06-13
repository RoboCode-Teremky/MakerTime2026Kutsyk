using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 5.0f;
    [SerializeField] GameObject enemyPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnTime);
    }

    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
