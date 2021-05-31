using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public void TakeDamage(float damage)
    {
        if (damage > 0) maxHealth -= damage;
        DestroyIfNotAlive();
    }

    private void DestroyIfNotAlive()
    {
        if (maxHealth <= 0) Destroy(gameObject);
    }
}