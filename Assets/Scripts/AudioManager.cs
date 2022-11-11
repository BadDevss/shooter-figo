using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip bulletSfx, laserSfx, explosionSfx, spawnSfx;

    public AudioClip BulletSfx { get => bulletSfx; }

    public AudioClip LaserSfx { get => laserSfx; }

    public AudioClip ExplosionSfx { get => explosionSfx; }

    public AudioClip SpawnSfx { get => spawnSfx; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayClip(AudioClip clipToPlay, GameObject objectWithSound, float volume = 1f)
    {
        AudioSource objectSource = objectWithSound.GetComponent<AudioSource>();
        if (objectSource == null)
        {
            objectSource = objectWithSound.AddComponent<AudioSource>();
            objectSource.spatialBlend = 0;
            objectSource.clip = clipToPlay;
            objectSource.volume = volume;
            objectSource.Play();
        }
        else
        {
            objectSource.volume = volume;
            objectSource.clip = clipToPlay;
            objectSource.Play();
        }
    }
}
