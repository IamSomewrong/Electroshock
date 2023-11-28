using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour
{

    Animator _animator;
    public int Health = 10;
    public GameObject Grave;
    public GameObject DeathScreen;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            _animator.SetBool("Dead", true);           
            Destroy(gameObject, 0.66f);
            if (gameObject.CompareTag("Player"))
            {
                StartCoroutine("WaitForDeath");
            }
            else
            {
                transform.GetComponentInParent<EnemiesRoom>().Check(GetComponent<BaseEnemyScript>());
            }
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(.65f);
        Instantiate(Grave, transform.position + new Vector3(0, 0.737f, 0), Quaternion.identity);
        Time.timeScale = 0;
        DeathScreen.SetActive(true);
    }

}
