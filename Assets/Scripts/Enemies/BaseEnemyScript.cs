using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{
    public float Speed;
    public float MinDistance;

    protected GameObject _target;
    protected Rigidbody2D _rigidbody;
    protected AudioSource _audioSource;

    public Animator _animator;

    void Start()
    { 
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player");
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(_target.transform.position + new Vector3(0, 0.737f, 0), transform.position) > MinDistance)
        {
            _rigidbody.velocity = (_target.transform.position + new Vector3(0, 0.737f, 0) - transform.position).normalized * Speed;
        }
        else
        {
            Attack();
            _rigidbody.velocity = Vector3.zero;
        }
        _animator.SetBool("GoingDown", _rigidbody.velocity.y < 0);
        _animator.SetBool("GoingUp", _rigidbody.velocity.y > 0);
    }

    virtual protected void Attack() { }
}
