using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private GameObject startChunk;
    [SerializeField] private GameObject ghost;

    private List<GameObject> spawnedChunks = new List<GameObject>();

    private void Start()
    {
        Instantiate(startChunk, transform.position, transform.rotation);
        spawnedChunks.Add(startChunk);
    }

    private void Update()
    {
        if (ghost.transform.position.y > spawnedChunks[spawnedChunks.Count - 1].transform.position.y - 10)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Vector3 nextChunkPos = spawnedChunks[spawnedChunks.Count - 1].transform.position;
        nextChunkPos.y += 2 * Camera.main.orthographicSize;
        GameObject newChunk = Instantiate(chunks[Random.Range(0, chunks.Length)], nextChunkPos, transform.rotation);
        spawnedChunks.Add(newChunk);
    }
}
