using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatSpawner : MonoBehaviour
{
    GameObject[] shortfloats;
    public GameObject shortPrefab;

    int currentIndex = 0;

    public float rateSpawnTime = 0f;
    public float spawnLastTime = 0f;

    public float rateMin = 3.35f;
    public float rateMax = 5f;

    float yLenMin = -2f;
    float yLenMax = 3.2f;
    
    float xPos = 40f;
    float yPos;

    Vector2 poolposition = new Vector2(0f, -30f);
    void Awake()
    {
        shortfloats = new GameObject[10];

        for(int i = 0;i<10;i++)
        {
            shortfloats[i] = Instantiate(shortPrefab,poolposition,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnLastTime + rateSpawnTime)
        {
            spawnLastTime = Time.time;
            rateSpawnTime = Random.Range(rateMin,rateMax);  
            yPos = Random.Range(yLenMin,yLenMax);

            shortfloats[currentIndex].transform.position = new Vector2 (xPos,yPos);

            currentIndex++;
            if(currentIndex == 10) currentIndex = 0;
        }
    }
}
