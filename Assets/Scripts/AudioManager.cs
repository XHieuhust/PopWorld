using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] AudioSource audioGamePlay;
    [SerializeField] AudioSource audioSoundEffect;
    [SerializeField] AudioSource audioSoundEffecLoop;
    [SerializeField] AudioSource audioClick;


    public AudioClip SFX_Wear;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this; 
        DontDestroyOnLoad(this);
    }

    public void PlaySoundEffect(AudioClip _audio)
    {
        if (_audio != null) audioSoundEffect.PlayOneShot(_audio);
    }

    public void PlaySoundEffectLoop(AudioClip _audio)
    {
        if (_audio != null)
        {
            audioSoundEffecLoop.clip = _audio;
            audioSoundEffecLoop.Play();
        }
    }

    public void PlayAudioClick()
    {
        audioClick.Play();
    }

    public void PlayMusicGamePlay(AudioClip _audio)
    {
        if (_audio != null)
        {
            audioGamePlay.clip = _audio;
            audioGamePlay.Play();
        }
    }

    public void StopAudioEffect()
    {
        audioSoundEffect.Stop();
        audioSoundEffecLoop.Stop();
    }

    public void StopSound()
    {
        audioGamePlay.Stop();
    }
}