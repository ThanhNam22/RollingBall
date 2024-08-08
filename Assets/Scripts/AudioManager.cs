using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    public AudioClip musicClip;
    public AudioClip coinClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip ballClip;

    void Start()
    {
        musicAudio.clip = musicClip;
        musicAudio.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudio.clip = clip; 
        sfxAudio.PlayOneShot(clip);
    } 
}
