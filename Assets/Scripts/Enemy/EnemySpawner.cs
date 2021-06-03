using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float minSpawnTimeThrowEntireGame;
    [SerializeField] private float minTimeBeetweenSpawn;
    [SerializeField] private float maxTimeBeetweenSpawn;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float startVertSpeed;
    [SerializeField] private float startGorSpeed;
    [SerializeField] private GameObject target;

    private float timeBetweenSpawn = 10f;
    private float timeFromPreviousSpawn;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Update()
    {
        if (timeFromPreviousSpawn >= timeBetweenSpawn)
        {
            Vector3 enemyPosition = transform.position;
            enemyPosition.x = Random.Range(minX, maxX);

            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], enemyPosition, transform.rotation, transform);
            enemy.GetComponent<EnemyMovement>().SetTarget(target);
            enemy.GetComponent<EnemyMovement>().SetVertSpeed(startVertSpeed);
            enemy.GetComponent<EnemyMovement>().SetGorSpeed(startGorSpeed);
            spawnedEnemies.Add(enemy);

            timeFromPreviousSpawn = 0f;
            timeBetweenSpawn = Random.Range(minTimeBeetweenSpawn, maxTimeBeetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }

        startVertSpeed += Time.deltaTime / 70;
        startGorSpeed += Time.deltaTime / 240;

        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            if (spawnedEnemies[i] != null)
            {
                if (spawnedEnemies[i].transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 2)
                {
                    Destroy(spawnedEnemies[i]);
                    spawnedEnemies.RemoveAt(i);
                }
            }
        }

        if (minTimeBeetweenSpawn > minSpawnTimeThrowEntireGame)
        {
            minTimeBeetweenSpawn -= Time.deltaTime / 80;
        }
        else if (maxTimeBeetweenSpawn > minSpawnTimeThrowEntireGame)
        {
            maxTimeBeetweenSpawn -= Time.deltaTime / 60;
        }
    }
}
