using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompasRune : MonoBehaviour
{
    ParticleSystem _particleSystem;
    SpriteRenderer _spriteRenderer;

    
    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _particleSystem.startColor = _spriteRenderer.color;
    }
}
