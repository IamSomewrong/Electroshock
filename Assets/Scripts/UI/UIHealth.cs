using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    Slider _healthSlider;
    FighterScript _playerHp;
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        _playerHp = GameObject.FindWithTag("Player").GetComponent<FighterScript>();
    }

    private void Update()
    {
        _healthSlider.value = _playerHp.Health;
    }
}
