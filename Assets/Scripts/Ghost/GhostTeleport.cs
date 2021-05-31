using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{
    [SerializeField] private float teleportDistance;

    public void OnTeleportButtonDown()
    {
        Vector3 pos = transform.position;
        pos.y += teleportDistance;
        transform.position = pos;
    }
}
