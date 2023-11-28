using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuButton1 : MonoBehaviour
{
    public GameObject Menu;
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void OpenMenu()
    {
        _audio.Play();
        StartCoroutine("WaitForSound");
    }

    IEnumerator WaitForSound()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(.33f);
        Menu.SetActive(false);
    }
}
