using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISettings : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void Master(float value)
    {
        AudioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
    }

    public void Music(float value)
    {
        AudioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }

    public void Effects(float value)
    {
        AudioMixer.SetFloat("Effects", Mathf.Log10(value) * 20);
    }

    public void UI(float value)
    {
        AudioMixer.SetFloat("UI", Mathf.Log10(value) * 20);
    }

    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Back()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundAuthors");
    }
    IEnumerator WaitForSoundAuthors()
    {

        yield return new WaitForSeconds(0.33f);
        transform.parent.GetChild(1).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Back2()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundAuthors2");
    }
    IEnumerator WaitForSoundAuthors2()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.33f);
        transform.parent.GetChild(1).gameObject.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
