using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 0.5f;
    [Header("Damaging")]
    [SerializeField] AudioClip damagingClip;
    [SerializeField][Range(0f, 1f)] float damagingVolume = 0.5f;
    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void PlayShooitngClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamagingClip()
    {
        PlayClip(damagingClip, damagingVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null) AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
