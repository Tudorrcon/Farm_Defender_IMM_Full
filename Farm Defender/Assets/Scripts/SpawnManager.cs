using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyHighPrefab;
    public GameObject enemyLowPrefab;
    public GameObject powerupPrefab;

    public GameManager gameManager;

    private float XLimit = 8.5f;
    private float spawnPosY = 0.4f;
    private float spawnPosZ = 10.5f;

    private float XLimit2 = 8.0f;
    private float spawnPosY2 = 1;
    private float ZLimit = 8.5f;

    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        powerupPrefab.SetActive(true);
        SpawnEnemyWave(waveNumber);
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 randomSpawnPos = new Vector3(Random.Range(-XLimit, XLimit), spawnPosY, spawnPosZ);
        return randomSpawnPos;
    }

    Vector3 GeneratePowerUpSpawnPosition()
    {
        Vector3 randomSpawnPos = new Vector3(Random.Range(-XLimit2, XLimit2), spawnPosY2, Random.Range(-ZLimit,ZLimit));
        return randomSpawnPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ScenePrimitive"))
        {
            if (enemiesToSpawn < 11) {
                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    Instantiate(enemyLowPrefab, GenerateSpawnPosition(), enemyLowPrefab.transform.rotation);
                }

                if (enemiesToSpawn == 3)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }
                else if (enemiesToSpawn == 6)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }
                else if (enemiesToSpawn == 9)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }

                if (enemiesToSpawn > 7 && enemiesToSpawn < 10)
                {
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                }
                else if (enemiesToSpawn > 9 && enemiesToSpawn < 11)
                {
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                }
            }
            else
            {
                if (gameManager.livesTotal > 0)
                {
                    gameManager.RoundWon();
                }
            }
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ScenePrimitive 1"))
        {
            if (enemiesToSpawn < 9)
            {
                Time.timeScale = 1;
                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    Instantiate(enemyLowPrefab, GenerateSpawnPosition(), enemyLowPrefab.transform.rotation);
                }

                if (enemiesToSpawn == 3)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }
                else if (enemiesToSpawn == 6)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }
                else if (enemiesToSpawn == 9)
                {
                    Instantiate(powerupPrefab, GeneratePowerUpSpawnPosition(), powerupPrefab.transform.rotation);
                }

                if (enemiesToSpawn > 3 && enemiesToSpawn < 5)
                {
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                }
                else if (enemiesToSpawn > 6 && enemiesToSpawn < 10)
                {
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                    Instantiate(enemyHighPrefab, GenerateSpawnPosition(), enemyHighPrefab.transform.rotation);
                }
            }
            else
            {
                if (gameManager.livesTotal > 0)
                {
                    gameManager.Winning();
                    Time.timeScale = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyLow>().Length + FindObjectsOfType<EnemyHigh>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber > 0 && waveNumber < 5)
            {
                enemyLowPrefab.GetComponent<EnemyLow>().speed = 3;
            }
            else if (waveNumber > 4 && waveNumber < 10)
            {
                enemyLowPrefab.GetComponent<EnemyLow>().speed = 4;
                enemyHighPrefab.GetComponent<EnemyHigh>().speed = 5;
            }
            else
            {
                enemyLowPrefab.GetComponent<EnemyLow>().speed = 6;
                enemyHighPrefab.GetComponent<EnemyHigh>().speed = 7;
            }
            SpawnEnemyWave(waveNumber); 
        }

        
    }
}
