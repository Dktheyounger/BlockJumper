using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health = 50f;

    [SerializeField]
    private ParticleSystem block;

    [SerializeField]
    private Renderer renderer;

    public void TakeDamage(float amount)
    {
        health -= amount;
        renderer.material.color = new Color(0.5f, 1, 1);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
