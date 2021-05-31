using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private GameObject target;

    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < radius)
        {
            target.GetComponent<GhostHealth>().TakeDamage(damage);
        }
    }
}