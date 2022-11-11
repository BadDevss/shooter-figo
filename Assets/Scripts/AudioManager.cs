using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip bulletSfx, laserSfx, explosionSfx, spawnSfx, engineDownSfx;

    public AudioClip BulletSfx { get => bulletSfx; }

    public AudioClip LaserSfx { get => laserSfx; }

    public AudioClip ExplosionSfx { get => explosionSfx; }

    public AudioClip SpawnSfx { get => spawnSfx; }

    //public AudioClip WindSfx { get => windSfx; }
    public AudioClip EngineDownSfx { get => engineDownSfx; }

    private bool offMusic = false;

    public bool OffMusic { get { return offMusic; } set
        {
            offMusic = value;
            DisableMusics();
        } 
    }

    private bool offSfx = false;

    public bool OffSfx
    {
        get { return offSfx; }
        set
        {
            offSfx = value;
            DisableSfx();
        }
    }

    //public bool OffSfx { get; set; } = false;

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

    private void OnEnable()
    {
        Debug.Log("Enable");
        SceneManager.sceneLoaded += DisableMusics;
        SceneManager.sceneLoaded += DisableSfx;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= DisableMusics;
        SceneManager.sceneLoaded -= DisableSfx;
    }

    public void DisableMusics(Scene scene = default, LoadSceneMode mode = default)
    {
        if (OffMusic)
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("SceneMusic"))
            {
                Debug.Log(gameObject.name);
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public void DisableSfx(Scene scene = default, LoadSceneMode mode = default)
    {
        if (OffMusic)
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("SceneSfx"))
            {
                Debug.Log(gameObject.name);
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public void PlayClip(AudioClip clipToPlay, GameObject objectWithSound, float volume = 1f)
    {
        if (OffSfx)
            return;

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
