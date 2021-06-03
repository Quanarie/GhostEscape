using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilSpawner : MonoBehaviour
{
    [SerializeField] private GameObject devilHandPrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minSpawnTimeThrowEntireGame;
    [SerializeField] private float minTimeBeetweenAttack;
    [SerializeField] private float maxTimeBeetweenAttack;
    [SerializeField] private AnimationClip attackAnimation;

    private float timeBetweenAttack = 20f;
    private float timeFromPreviousAttack;

    void Update()
    {
        if (timeFromPreviousAttack >= timeBetweenAttack)
        {
            Vector3 pos = transform.position;
            pos.x = Random.Range(minX, maxX);

            GameObject devilHand = Instantiate(devilHandPrefab, pos, transform.rotation, transform);
            Destroy(devilHand, attackAnimation.length);
            GetComponent<AudioSource>().Play();

            timeFromPreviousAttack = 0f;
            timeBetweenAttack = Random.Range(minTimeBeetweenAttack, maxTimeBeetweenAttack);
        }
        else
        {
            timeFromPreviousAttack += Time.deltaTime;
        }

        if (minTimeBeetweenAttack > minSpawnTimeThrowEntireGame)
        {
            minTimeBeetweenAttack -= Time.deltaTime * 0.05f;
        }
        else if (maxTimeBeetweenAttack > minSpawnTimeThrowEntireGame)
        {
            maxTimeBeetweenAttack -= Time.deltaTime * 0.05f;
        }
    }
}
