using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float gorizontalSpeed;
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= verticalSpeed * Time.deltaTime;
        if (pos.y > target.position.y)
            pos.x += (target.position.x - transform.position.x) * gorizontalSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
