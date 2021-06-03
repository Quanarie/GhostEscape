using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private float startSpeed;

    private List<GameObject> spawnedChunks = new List<GameObject>();

    private void Start()
    {
        GameObject startChunk = Instantiate(chunks[Random.Range(0, chunks.Length)], transform.position, transform.rotation, transform);
        spawnedChunks.Add(startChunk);
        startChunk.SetActive(false);
    }

    private void Update()
    {
        if (spawnedChunks[spawnedChunks.Count - 1].transform.position.y <= transform.position.y)
        {
            Vector3 newChunkPos = transform.position;
            newChunkPos.y += 2 * Camera.main.orthographicSize;

            GameObject newChunk = Instantiate(chunks[Random.Range(0, chunks.Length)], newChunkPos, transform.rotation, transform);
            spawnedChunks.Add(newChunk);
        }

        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            if (spawnedChunks[i].transform.position.y < transform.position.y - 2 * Camera.main.orthographicSize)
            {
                Destroy(spawnedChunks[i]);
                spawnedChunks.RemoveAt(i);
            }
        }
    }
}
