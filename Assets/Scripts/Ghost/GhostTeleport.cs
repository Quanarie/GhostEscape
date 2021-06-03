using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{
    [SerializeField] private float teleportDistance;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        GetComponent<SwipeDetector>().OnSwipe += OnTeleport;
    }

    public void OnTeleport()
    {
        Vector3 pos = transform.position;
        pos.y += teleportDistance;
        transform.position = pos;

        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
