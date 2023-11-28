using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float Speed = 1f;

    Animator _anim;
    SpriteRenderer _spriteRenderer;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        Vector2 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _anim.SetBool("RunningDown", dir.y < 0);
        _anim.SetBool("RunningRight", dir.x > 0);
        _anim.SetBool("RunningLeft", dir.x < 0);
        _anim.SetBool("RunningUp", dir.y > 0);
        _rb.velocity = dir * Speed;
        if(_rb.velocity == Vector2.zero)
        {
            _audioSource.Play();
        }
}
}
