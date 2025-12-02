using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected UIDisplay ui;
    [SerializeField] protected int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    protected AudioPlayer audioPlayer;
    public int Score { get { return score; } }

    protected virtual void Awake()
    {        
        ui = FindAnyObjectByType<UIDisplay>();
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {            
            PlayHitEffect();
            audioPlayer.PlayDamagingClip();
            TakeDamage(damageDealer.Damage);
            damageDealer.Hit();
        }
    }
    protected virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    protected void PlayHitEffect()
    {
        ParticleSystem particleSystem = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(particleSystem, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
    }
    protected virtual void Die()
    {
        ui.AddScore(score);
        Destroy(gameObject);
    }
}
