using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject _player;

    [Range(0f, 1f)]
    public float Rigity = 0.5f;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z), Rigity);
    }
}
