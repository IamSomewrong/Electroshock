using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public List<AudioClip> Clips;
    AudioSource _audioSource;
    int _clipNumber = 1;
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = Clips[0];
        _audioSource.Play();
        StartCoroutine("ChangeMusic");
    }

    IEnumerator ChangeMusic()
    {
        yield return new WaitForSeconds(_audioSource.clip.length + 5);
        _audioSource.clip = Clips[_clipNumber];
        _audioSource.Play();
        _clipNumber = (_clipNumber + 1) % Clips.Count;
        StartCoroutine("ChangeMusic");
    }
}
