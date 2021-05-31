using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{
    [SerializeField] private float teleportMultiplier;
    [SerializeField] private Joystick joystick;

    private float timeBetweenClicks = 0.2f;

    public void OnTeleportButtonDown()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;

        Vector3 pos = transform.position;
        pos.x += xAxis * teleportMultiplier;
        pos.y += yAxis * teleportMultiplier;
        transform.position = pos;
    }
}
