using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpeedup : MonoBehaviour
{
    [SerializeField] private GameObject[] chunks;

    private List<ChunkMovement> chunksMoveComponents = new List<ChunkMovement>();

    private void Start()
    {
        foreach (GameObject chunk in chunks)
        {
            chunksMoveComponents.Add(chunk.GetComponent<ChunkMovement>());
        }
    }

    private void Update()
    {
        foreach (ChunkMovement chunk in chunksMoveComponents)
        {
            chunk.AddSpeed(Time.deltaTime / 60);
        }
    }
}
