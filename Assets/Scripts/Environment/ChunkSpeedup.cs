using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpeedup : MonoBehaviour
{
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private float startSpeed;

    private List<ChunkMovement> chunksMoveComponents = new List<ChunkMovement>();

    private void Start()
    {
        foreach (GameObject chunk in chunks)
        {
            chunksMoveComponents.Add(chunk.GetComponent<ChunkMovement>());
            chunk.GetComponent<ChunkMovement>().SetSpeed(startSpeed);
        }
    }

    private void Update()
    {
        foreach (ChunkMovement chunk in chunksMoveComponents)
        {
            chunk.AddSpeed(Time.deltaTime / 80);
        }
    }
}
