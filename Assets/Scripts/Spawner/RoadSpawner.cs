using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject Prefab;
    GameObject[] Roads;
    public int count;

    float rateTime = 0f;
    public float rateMin = 6.25f;
    public float rateMax = 6.25f;

    float spawnLastTime = 0f;
    float xPos = 40f;
    float yPos = -2.46f;

    int currentIndex = 0;

    Vector2 poolPosition = new Vector2 (0f,-25f);
    void Awake()
    {
        Roads = new GameObject[count];

        for(int i = 0;i<count;i++)
        {
            Roads[i] = Instantiate(Prefab,poolPosition,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >  spawnLastTime + rateTime)
        {
            spawnLastTime = Time.time;
            rateTime = Random.Range(rateMin,rateMax);

            Roads[currentIndex].transform.position = new Vector2(xPos,yPos);
            currentIndex++;

            if(currentIndex == count) currentIndex = 0;
        }
    }
}
