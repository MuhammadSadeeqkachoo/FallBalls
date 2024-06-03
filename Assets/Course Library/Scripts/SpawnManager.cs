using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {

        spawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateRandomSpawnPos(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateRandomSpawnPos(), enemyPrefab.transform.rotation);

        }
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawnPos()
    {
        float SpawnPosX = Random.Range(-spawnRange, spawnRange);
        float SpawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 RandPos = new Vector3(SpawnPosX, 0, SpawnPosZ);
        return RandPos;
    }
}
