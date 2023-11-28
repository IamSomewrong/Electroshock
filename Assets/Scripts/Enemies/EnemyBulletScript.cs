using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    Rigidbody2D _rb;
    public float Speed = 1.0f;
    public int Damage = 5;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.right * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<FighterScript>().TakeDamage(Damage);
        }
        if(!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
