using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private void Start()
    {
        GetComponent<SwipeDetector>().OnClick += OnAttack;
    }

    public void OnAttack()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        GetComponent<AudioSource>().Play();
    }
}