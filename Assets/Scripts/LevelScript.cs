using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int StonesGathered = 0;
    public int StonesGatheredNeed;

    public void Check()
    {
        StonesGathered += 1;
        if (StonesGathered == StonesGatheredNeed)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
