using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    LevelScript _level;
    TMP_Text _count;
    private void Start()
    {
        _level = GameObject.FindObjectOfType<LevelScript>();
        _count = transform.GetChild(1).GetComponent<TMP_Text>();
        transform.GetChild(0).GetComponent<TMP_Text>().text = _level.StonesGatheredNeed.ToString();
    }

    private void Update()
    {
        _count.text = _level.StonesGathered.ToString();
    }
}
