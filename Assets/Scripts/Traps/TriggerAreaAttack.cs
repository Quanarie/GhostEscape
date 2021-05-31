using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaAttack : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GhostHealth _))
        {
            collision.GetComponent<GhostHealth>().TakeDamage(damage);
        }
    }
}
