using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchersWire : SwitchersBase
{
    public List<Sprite> Sprites;
    private void Update()
    {
        Status = _prev.Status;
        if (Status)
        {
            _sprite.sprite = Sprites[0];
        }
        else
        {
            _sprite.sprite = Sprites[1];
        }
    }

}
