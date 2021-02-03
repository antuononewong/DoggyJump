using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolfSpawner : MonoBehaviour
{
    // Dependancies
    public GameObject enemyWolf;
    public GameObject spawnPositions;
    public GameObject target;
    public GameObject menuHandler;

    // Spawn pattern
    private float _maxSpawnTimer = 15.0f;
    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = _maxSpawnTimer;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer < 0)
        {
            SpawnWolf();
        }

    }

    private void SpawnWolf()
    {
        GameObject wolf = Instantiate<GameObject>(enemyWolf);
        wolf.GetComponent<EnemyWolfController>().spawnPositions = spawnPositions;
        wolf.GetComponent<EnemyWolfController>().target = target;
        wolf.GetComponent<EnemyWolfController>().menuHandler = menuHandler;
        _spawnTimer = _maxSpawnTimer;
    }
}
