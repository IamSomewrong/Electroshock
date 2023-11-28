using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyScript : BaseEnemyScript
{
    public GameObject Bullet;

    public int ReloadTime;

    float _reloadTimer;

    protected override void Attack()
    {
    
        if (_reloadTimer > 0)
        {
            _reloadTimer -= Time.deltaTime;
        }
        else 
        {
            Vector3 difference = _target.transform.position - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Instantiate(Bullet, transform.position, Quaternion.Euler(0f, 0f, rotZ));
            _audioSource.Play();

            _reloadTimer = ReloadTime;
            
        } 
    }
}
