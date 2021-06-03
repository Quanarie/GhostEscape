using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float gorizontalSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= verticalSpeed * Time.deltaTime;
        if (pos.y > target.position.y - 2)
        {
            pos.x += (target.position.x - transform.position.x) * gorizontalSpeed * Time.deltaTime;

        }
        transform.position = pos;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target.transform;
    }

    public void SetVertSpeed(float speed)
    {
        if (speed >= 0) verticalSpeed = speed;
    }
    public void SetGorSpeed(float speed)
    {
        if (speed >= 0) gorizontalSpeed = speed;
    }
}
