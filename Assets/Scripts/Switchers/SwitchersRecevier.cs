using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchersRecevier : SwitchersBase
{
    public List<Sprite> Sprites;
    bool _win = false;
    public StoneScript Stone;
    GameObject _particleSystem;

    private void Start()
    {
        _particleSystem = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (Status)
        {
            StartCoroutine("WaitForWin");
            _sprite.sprite = Sprites[0];
            _particleSystem.SetActive(true);
        }
        else
        {
            _sprite.sprite = Sprites[1];
            _particleSystem.SetActive(false);
        }
        Status = _prev.Status;
    }

    IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(0.5f);
        if (Status && !_win)
        {
            _win = true;
            Stone.Appear();
        }
    }
}
