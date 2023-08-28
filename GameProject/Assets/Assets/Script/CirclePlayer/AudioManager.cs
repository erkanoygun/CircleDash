using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip[] clips;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    
    public void PlaySoundEffect(int index)
    {
        //_audioSource.clip = clip;
        _audioSource.PlayOneShot(clips[index]);
    }
}
