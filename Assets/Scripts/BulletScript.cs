using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D _rb;
    public float Speed = 1.0f;
    public int Damage = 5;
    public GameObject Light;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.5f);
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.right * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<SwitchersSwitch>(out SwitchersSwitch sw))
        {
            sw.MakeSwitch();
            Destroy(gameObject);
        }
        if (collision.TryGetComponent<HonkaiCircleBase>(out HonkaiCircleBase cb))
        {
            cb.gameObject.GetComponentInParent<HonkaiCircle>().Check(cb);
            Destroy(gameObject);
        }
        if (collision.TryGetComponent<StoneScript>(out StoneScript stone))
        {
            stone.Gather();
            Destroy(gameObject);
        }
        if(collision.TryGetComponent<CompasRune>(out CompasRune compasRune))
        {
            compasRune.gameObject.GetComponentInParent<Compas>().Rotate(compasRune.GetComponentInParent<CompasBase>());
            Destroy(gameObject);
        }
        if(!collision.CompareTag("Player") && collision.TryGetComponent<FighterScript>(out FighterScript fighter))
        {
            GameObject tmpLight = Instantiate(Light, collision.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            tmpLight.GetComponent<Animator>().enabled = true;
            tmpLight.GetComponent<AudioSource>().Play();
            Destroy(tmpLight, 2f);
            fighter.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
