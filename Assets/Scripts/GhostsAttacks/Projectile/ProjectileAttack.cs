using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)    //Destructable layer
        {
            Instantiate(deathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
