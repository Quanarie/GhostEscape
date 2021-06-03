using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.GetComponent<GhostHealth>().TakeDamage(damage);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
