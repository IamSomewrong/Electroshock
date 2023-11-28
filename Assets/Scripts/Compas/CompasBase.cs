using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompasBase : MonoBehaviour
{
    public float Angle;
    public bool Activated;
    public List<CompasBase> AttachedCircles;
    public Color ActivatedColor;
    public Color DeactivatedColor;

    SpriteRenderer[] _spriteRenderers;

    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        foreach (var renderer in _spriteRenderers)
        {
            renderer.color = Activated ? ActivatedColor : DeactivatedColor;
        }
    }
    public void Rotate(bool chain)
    {
        transform.Rotate(0, 0, -Angle);
        if (chain) 
        {
            foreach (var comp in AttachedCircles)
            {
                comp.Rotate(false);
            }
        }
    }
    public void Activate()
    {
        Activated = true;
    }

    public void Deactivate()
    {
        Activated = false;
    }
}
