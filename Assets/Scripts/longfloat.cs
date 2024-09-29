using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longfloat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] items;
    int i;
    void OnEnable()
    {
        i = Random.Range(0, items.Length);
        
        if(Random.Range(0, 3) == 0)
        {
            items[i].SetActive(true);
        }
           
    }

}
