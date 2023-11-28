using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkaiCircle : MonoBehaviour
{
    public List<HonkaiCircleBase> Circles;
    
    public List<GameObject> Emblem;
    public List<GameObject> Target;

    public StoneScript Stone;

    bool _win = false;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Check(HonkaiCircleBase circle)
    {
        _audioSource.Play();
        if (!circle.Checked)
        {
            foreach (var c in Circles)
            {
                c.UnCheck();
            }
            circle.Check();
        }
        else
        {
            for (int i = 0; i < Emblem.Count; i++)
            {
                circle.Rotate(Emblem[i]);
            }
            bool flag = true;
            for (int i = 0; i < Emblem.Count; i++)
            {
                flag &= Emblem[i].transform.parent.gameObject == Target[i];
            }
            if (!_win && flag)
            {
                _win = true;
                Stone.Appear();
            }
        }
        
    }
}
