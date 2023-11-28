using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public void Appear()
    {
        GetComponentInChildren<Animator>().enabled = true;
        GetComponentInChildren<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void Gather()
    {
        GameObject.FindObjectOfType<LevelScript>().Check();
        Destroy(gameObject);
    }
}
