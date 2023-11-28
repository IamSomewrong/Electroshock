using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkaiCircleBase : MonoBehaviour
{
    public bool Checked = false;
    public List<Sprite> Sprites;
    public List<GameObject> Circles;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Checked)
        {
            _spriteRenderer.sprite = Sprites[0];
        }
        else
        {
            _spriteRenderer.sprite = Sprites[1];
        }
    }

    public void Check()
    {
        Checked = true;
    }

    public void Rotate(GameObject emblem)
    {
        if (Circles.Contains(emblem.transform.parent.gameObject))
        {
            emblem.transform.SetParent(Circles[(Circles.IndexOf(emblem.transform.parent.gameObject) + 1) % Circles.Count].transform, false);
        }
    }

    public void UnCheck()
    {
        Checked = false;
    }
}
