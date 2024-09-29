using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsOnable : MonoBehaviour
{
    public GameObject[] onTheRoads;

    // Start is called before the first frame update
    private void OnEnable()
    {
        switch(Random.Range(0,10))
        { 
            case 0:
                onTheRoads[0].SetActive(true); break;
            case 1:
                onTheRoads[1].SetActive(true); break;
            case 2:
                onTheRoads[1].SetActive(true); break;
            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
