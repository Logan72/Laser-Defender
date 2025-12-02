using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{    
    CameraShaking cameraShaking;
    [SerializeField] LevelManager levelManager;

    protected override void Awake()
    {
        ui = FindAnyObjectByType<UIDisplay>();
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        ui.UpdateHealth(health);
        cameraShaking = Camera.main.GetComponent<CameraShaking>();
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ui.UpdateHealth(health);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            cameraShaking.ShakeCamera();
            PlayHitEffect();
            audioPlayer.PlayDamagingClip();
            TakeDamage(damageDealer.Damage);
            Health obj = damageDealer.GetComponent<Health>();
            if (obj != null)
            {
                ui.AddScore(obj.Score);
            }
            damageDealer.Hit();
        }
    }
    protected override void Die()
    {
        Destroy(gameObject);
        levelManager.LoadGameOverScene();
    }
}
