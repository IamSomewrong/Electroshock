using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButton : MonoBehaviour
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
        Menu.SetActive(true);
        Time.timeScale = 0;
    }
}
