using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compas : MonoBehaviour
{
    public List<CompasBase> Circles;

    public int WinRotation;

    public StoneScript Stone;
    bool _win = false;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Rotate(CompasBase circle)
    {
        _audioSource.Play();
        if (circle.Activated)
        {
            circle.Rotate(true);
        }
        else
        {
            foreach(CompasBase c in Circles)
            {
                c.Deactivate();
            }
            circle.Activate();
        }
        bool flag = true;
        for (int i = 0; i < Circles.Count; i++)
        {
            flag &= Mathf.Abs(Circles[i].transform.rotation.eulerAngles.z - WinRotation) < 0.001;
        }
        if (!_win && flag)
        {
            _win = true;
            Stone.Appear();
        }
    }
}
