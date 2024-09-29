using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRoad : MonoBehaviour
{
    float speed;

    public GameObject[] items;

    int itemcnt =3;

    void OnEnable()
    {
        int i = Random.Range(0, itemcnt);

        if (i == 0)
        {
            if(Random.Range(0, 1) == 0)
            {
                items[i].SetActive(true);
            }
        }
        else if (i == 1)
        {
            if (Random.Range(0, 2) == 0)
            {
                items[i].SetActive(true);
            }
        }

    }
}
