using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private const float screenWidth = 750f;
    private const float screenHeight = 1334f;

    private void Update()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;

        Vector3 pos = transform.position;
        pos.x += xAxis * Time.deltaTime * speed;
        pos.y += yAxis * Time.deltaTime * speed;

        if (pos.x < minX) pos.x = minX;

        if (pos.x > maxX) pos.x = maxX;

        if (pos.y > maxY) pos.y = maxY;

        if (pos.y < minY) pos.y = minY;

        transform.position = pos;
    }
}
