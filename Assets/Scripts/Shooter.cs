using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [HideInInspector] public bool isFiring = false;
    [Header("General")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 2f;
    [SerializeField] GameObject projectile;
    Coroutine firingCoroutine;
    [SerializeField] float reloadTime = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float reloadTimeVariance = 0;
    [SerializeField] float minReloadTime = 0.1f;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    public IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.GetComponent<Rigidbody2D>().linearVelocity = transform.up * projectileSpeed;
            audioPlayer.PlayShooitngClip();
            Destroy(projectileInstance, projectileLifetime);

            float delayTime = UnityEngine.Random.Range(reloadTime - reloadTimeVariance, reloadTime + reloadTimeVariance);
            delayTime = Mathf.Clamp(delayTime, minReloadTime, float.MaxValue);
            yield return new WaitForSeconds(delayTime);
        }        
    }
}
