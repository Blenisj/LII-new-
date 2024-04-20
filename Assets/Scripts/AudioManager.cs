using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("-------- Audio Clips --------")]
    public AudioClip introSong;
    public AudioClip backGround;
    public AudioClip bossBattle;
    public AudioClip death;
    public AudioClip shoot;
    public AudioClip LaserGun;

    // Singleton pattern to keep the audio manager consistent across scenes
    public static AudioManager instance;

    private void Awake()
    {
        // Ensure the audio manager persists across scene changes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called every time a scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Determine the current scene and play the appropriate music
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(introSong);
                break;
            case "MapLayout":
                PlayMusic(backGround);
                break;
            case "SampleScene":
                PlayMusic(bossBattle);
                break;
            default:
                musicSource.Stop();
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
       if (musicSource.isPlaying)
            musicSource.Stop();

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void OnDestroy()
    {
        // Clean up the delegate to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}