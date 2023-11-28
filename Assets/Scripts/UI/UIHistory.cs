using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHistory : MonoBehaviour
{
    public float typingSpeed = 0.1f; // Скорость печати текста 
    private string fullText;
    private string currentText = "";

    private TMP_Text textComponent;
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        textComponent = GetComponent<TMP_Text>();
        fullText = textComponent.text;
        textComponent.text = "";
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            currentText += c;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        Skip();
    }

    public void Skip()
    {
        _audio.Play();
        transform.parent.GetComponent<AudioSource>().Stop();
        StopAllCoroutines();
        textComponent.text = fullText;
        transform.parent.GetChild(1).gameObject.SetActive(false);
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    public void Continue()
    {
        _audio.Play();
        StartCoroutine("WaitForSound");
    }

    IEnumerator WaitForSound() 
    {
        yield return new WaitForSeconds(0.33f);
        SceneManager.LoadScene(3);
    }

    public void Final()
    {
        _audio.Play();
        StartCoroutine("WaitForSoundFinal");
    }

    IEnumerator WaitForSoundFinal()
    {
        yield return new WaitForSeconds(0.33f);
        SceneManager.LoadScene(1);
    }
}
