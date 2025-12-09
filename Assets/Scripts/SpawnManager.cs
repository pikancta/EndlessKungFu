using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject enemyPrefab;

    [Header("Spawn Settings")]
    public float spawnX = 10f;       
    public float spawnYMin = -3.4f;
    public float spawnYMax = 3f;

    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 2f;
    private float nextSpawnTime;
    void Start()
    {
        SetNextSpawnTime();
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }
    void SpawnEnemy()
    {
        float y = Random.Range(spawnYMin, spawnYMax);
        Vector3 pos = new Vector3(spawnX, y, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}


