using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void Exit()
    {
        _audio.Play();
        Application.Quit();
    }
    public void StartButton()
    {
        _audio.Play();
        StartCoroutine("WaitForSound");
    }
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(0.33f);
        SceneManager.LoadScene(2);
    }

    public void Authors()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundAuthors");
    }

    IEnumerator WaitForSoundAuthors()
    {
        yield return new WaitForSeconds(0.33f);
        transform.parent.GetChild(2).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundSettings");
    }

    IEnumerator WaitForSoundSettings()
    {
        yield return new WaitForSeconds(0.33f);
        transform.parent.GetChild(3).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
