using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GhostHealth _))
        {
            collision.GetComponent<GhostHealth>().TakeDamage(damage);
            Instantiate(effect, collision.transform.position, collision.transform.rotation);
        }
    }
}
