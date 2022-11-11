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
}
