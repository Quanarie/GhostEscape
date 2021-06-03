using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject chunk;

    private float scoreValue = 0f;

    private void Update()
    {
        score.text = "Score: " + ((int)scoreValue).ToString();
        scoreValue += chunk.GetComponent<ChunkMovement>().GetChunkSpeed() * Time.deltaTime;
    }

    public void SetScore(float score)
    {
        scoreValue = score;
    }
}
