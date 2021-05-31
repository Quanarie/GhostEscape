using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private GameObject target;

    private float timeFromPreviousSpawn;
    private void Update()
    {
        if (timeFromPreviousSpawn >= timeBetweenSpawn)
        {
            Vector3 enemyPosition = transform.position;
            enemyPosition.x = Random.Range(minX, maxX);

            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], enemyPosition, transform.rotation, transform);
            enemy.GetComponent<EnemyAttack>().SetTarget(target);
            enemy.GetComponent<EnemyMovement>().SetTarget(target);

            timeFromPreviousSpawn = 0f;
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
}
