using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("-------- Audio Clip --------")]
    public AudioClip introSong;
    public AudioClip backGround;
    public AudioClip death;
    public AudioClip shoot;
    public AudioClip laserGun;
    public AudioClip bossBattle;
    private void Start()
    {
        musicSource.clip = backGround;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
