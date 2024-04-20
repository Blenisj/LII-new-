using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("-------- Audio Clip --------")]
    public AudioClip introSong;
    public AudioClip backGround;
    public AudioClip death;
    public AudioClip shoot;
    private void Start()
    {
        musicSource.clip = introSong;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
    }


}

