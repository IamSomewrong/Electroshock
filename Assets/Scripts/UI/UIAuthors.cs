using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAuthors : MonoBehaviour
{
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
}
