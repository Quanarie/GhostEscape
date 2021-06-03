using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }

    public float GetChunkSpeed()
    {
        return speed;
    }

    public void AddSpeed(float speed)
    {
        if (speed > 0)
        {
            this.speed += speed;
        }
    }
    public void SetSpeed(float speed)
    {
        if (speed >= 0)
        {
            this.speed = speed;
        }
    }
}
