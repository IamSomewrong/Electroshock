using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchersSwitch : SwitchersBase
{
    public bool Switch = false;

    public List<SwitchersSwitch> Switchers;

    public List<Sprite> Sprites;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Switch)
        {
            if (_prev.Status)
            {
                Status = true;
                _sprite.sprite = Sprites[0];
            }
            else
            {
                Status = false;
                _sprite.sprite = Sprites[1];
            }
        }
        else
        {
            if (_prev.Status)
            {
                Status = false;
                _sprite.sprite = Sprites[2];
            }
            else
            {
                Status = false;
                _sprite.sprite = Sprites[3];
            }
        }
    }

    public void MakeSwitch()
    {
        _audioSource.Play();
        Switch = !Switch;
        foreach (var switcher in Switchers)
        {
            switcher.Switch = !switcher.Switch;
        }
    }
}
