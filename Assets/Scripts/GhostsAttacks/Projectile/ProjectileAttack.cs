using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)    //Destructable layer
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
