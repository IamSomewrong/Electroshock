using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : BaseEnemyScript
{

    public int Damage;
    protected override void Attack()
    {
        _animator.SetBool("Attacking", true);
        StartCoroutine("WaitForAttack");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent<FighterScript>(out FighterScript fighter))
        {
            fighter.TakeDamage(Damage);
            _audioSource.Play();
        }
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1);
        _animator.SetBool("Attacking", false);
    }
}
