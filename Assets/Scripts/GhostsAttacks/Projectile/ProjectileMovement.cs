using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * speed;
        transform.position = pos;

        if (pos.y - startPos.y > distance) Destroy(gameObject);
    }
}
