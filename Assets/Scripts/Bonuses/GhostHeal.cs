using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHeal : MonoBehaviour
{
    [SerializeField] private float toHeal;
    [SerializeField] private ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GhostHealth _))
        {
            collision.GetComponent<GhostHealth>().Heal(toHeal);
            Instantiate(effect, collision.transform.position, collision.transform.rotation);

            Destroy(gameObject);
        }
    }
}
