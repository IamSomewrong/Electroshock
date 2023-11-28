using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    AudioSource _audio;
    public GameObject Setting;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void Exit()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundExit");
    }

    public void MainMenu()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundMainMenu");
    }

    IEnumerator WaitForSoundMainMenu()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.33f);
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitForSoundExit()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.33f);
        Application.Quit();
    }
    public void Settings()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundSettings");
    }
    IEnumerator WaitForSoundSettings()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.33f);
        Setting.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
