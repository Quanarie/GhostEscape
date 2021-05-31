using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    public void OnAttackButtonDown()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}