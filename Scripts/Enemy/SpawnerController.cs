using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Dependancies
    public GameObject player;
    public GameObject rat;
    public GameObject blacky;
    public GameObject menuHandler;

    // Adjustable
    public float speed = 1.5f;

    // Spawn pattern
    private float _maxSpawnTimer = 10.0f;
    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = 0.0f;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer < 0)
        {
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        int spawnNumber = Random.Range(0, transform.childCount);
        int mobType = Random.Range(0, 2);
        Vector3 spawnPosition = transform.GetChild(spawnNumber).position;

        switch (mobType)
        {
            case 0:
                GameObject newRat = Instantiate<GameObject>(rat);
                newRat.GetComponent<RatController>().target = player.transform;
                newRat.GetComponent<RatController>().menuHandler = menuHandler;
                newRat.transform.position = spawnPosition;
                break;
            case 1:
                GameObject newBlacky = Instantiate<GameObject>(blacky);
                newBlacky.GetComponent<BlackyController>().menuHandler = menuHandler;
                newBlacky.transform.position = spawnPosition;
                break;
        }

        _spawnTimer = Random.Range(2, _maxSpawnTimer);
    }
}
