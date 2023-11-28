using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject Exit;
    public Vector3 Offset;
    public List<Sprite> Sprites;
    public GameObject Light;
    public GameObject Enemies;

    bool _canReplace = false;
    GameObject _player;
    SpriteRenderer _spriteRenderer;
    GameObject _particleSystem;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canReplace = true;
            _player = collision.gameObject;
            _spriteRenderer.sprite = Sprites[0];
            _particleSystem.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canReplace = false;
            _spriteRenderer.sprite = Sprites[1];
            _particleSystem.SetActive(false);
        }
    }

    private void Update()
    {
        if (_canReplace && _player.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _player.transform.position = Exit.transform.position + Offset;
            Camera.main.transform.position = new Vector3(Exit.transform.position.x + Offset.x, Exit.transform.position.y + Offset.y, Camera.main.transform.position.z);
            GameObject tmpLight = Instantiate(Light, Exit.transform.position + Offset + new Vector3(0, 3, 0), Quaternion.identity);
            tmpLight.GetComponent<Animator>().enabled = true;
            tmpLight.GetComponent<AudioSource>().Play();
            Destroy(tmpLight, 2);
            if(Enemies != null)
            {
                Enemies.SetActive(!Enemies.active);
            }
        }
    }
}
