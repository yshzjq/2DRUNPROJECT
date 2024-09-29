using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject[] roads;
    int count = 3;

    void OnEnable()
    {
        for(int i = 0;i< count; i++)
        {
            if(Random.Range(0,6) == 0 )
            {
                roads[i].SetActive(true);
            }
        }
    }
}
