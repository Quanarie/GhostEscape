using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfFullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private AudioClip healAudio;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if ((i + 1) * 2 <= currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else if ((i + 1) * 2 == currentHealth + 1)
            {
                hearts[i].sprite = halfFullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0) currentHealth -= damage;
        DestroyIfNotAlive();
    }

    public void Heal(float toHeal)
    {
        if (toHeal > 0) currentHealth = Mathf.Min(currentHealth + toHeal, maxHealth);
        GetComponent<AudioSource>().PlayOneShot(healAudio);
    }

    private void DestroyIfNotAlive()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
