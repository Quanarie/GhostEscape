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
    [SerializeField] private GameObject target;

    private float timeBetweenSpawn;
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
            spawnedEnemies.Add(enemy);

            timeFromPreviousSpawn = 0f;
            timeBetweenSpawn = Random.Range(minTimeBeetweenSpawn, maxTimeBeetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }

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
            minTimeBeetweenSpawn -= Time.deltaTime * 0.025f;
        }
        else if (maxTimeBeetweenSpawn > minSpawnTimeThrowEntireGame)
        {
            maxTimeBeetweenSpawn -= Time.deltaTime * 0.05f;
        }
    }
}
