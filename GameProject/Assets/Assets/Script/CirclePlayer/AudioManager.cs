using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip[] clips;
    GameManager _gameManagerScr;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManagerScr = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    
    public void PlaySoundEffect(int index)
    {
        if(_gameManagerScr.isSoundActive)
            _audioSource.PlayOneShot(clips[index]);
    }
}
