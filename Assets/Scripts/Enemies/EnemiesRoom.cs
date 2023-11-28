using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRoom : MonoBehaviour
{
    public List<BaseEnemyScript> Enemies;

    public StoneScript Stone;

    bool _win = false;


    public void Check(BaseEnemyScript enemy)
    {
        Enemies.Remove(enemy);
        if (!_win && Enemies.Count == 0)
        {
            _win = true;
            GameObject.FindWithTag("Player").GetComponent<FighterScript>().Health = 10;
            Stone.Appear();
        }
    }
}
