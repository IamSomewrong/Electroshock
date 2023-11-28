using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchersBase : MonoBehaviour
{
    public bool Status = false;
    public GameObject Prev;

    protected SwitchersBase _prev;
    protected SpriteRenderer _sprite;

    private void Awake()
    {
        if (Prev != null)
        {
            _prev = Prev.GetComponent<SwitchersBase>();
        }
       _sprite = GetComponentInChildren<SpriteRenderer>();
    }

}
