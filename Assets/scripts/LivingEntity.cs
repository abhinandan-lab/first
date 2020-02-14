using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour,DamagableInterface
{
    GameRecords gr;
    public float startingHealth=1f;

    protected float health;

    protected virtual void Start()
    {
        gr = FindObjectOfType<GameRecords>();
        health = startingHealth;
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        gr.enemiesDied++;
    }
}
