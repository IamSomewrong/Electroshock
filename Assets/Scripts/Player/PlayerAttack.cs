using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float ReloadTime = 1f;
    public GameObject Bullet;
    public ParticleSystem Particle;
    Transform _bulletSpawn;
    float _reloadTimer;
    Animator _animator;

    void Start()
    {
        _reloadTimer = ReloadTime;
        _bulletSpawn = transform.GetChild(0);
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Particle.Play();
            _animator.SetBool("Attacking", true);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_reloadTimer < 0) 
            {
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _bulletSpawn.position;
                difference.Normalize();

                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                
                Instantiate(Bullet, _bulletSpawn.position, Quaternion.Euler(0f, 0f, rotZ));
                _reloadTimer = ReloadTime;
            }
            else
            {
                _reloadTimer -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Particle.Stop();
            _animator.SetBool("Attacking", false);
            _reloadTimer = ReloadTime;
        }
    }
}
