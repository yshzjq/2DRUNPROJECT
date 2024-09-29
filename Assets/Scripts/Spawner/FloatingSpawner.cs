using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSpawner : MonoBehaviour
{
    public GameObject Prefab;
    GameObject[] Floats;
    public int count = 10;

    float rateTime = 0f;
    public float rateMin = 0.5f;
    public float rateMax = 3f;

    public float spawnLastTime = 0f;
    float xPos = 20f;
    float yPos;
    float yPosMax = 3.5f;
    float yPosMin = -2.46f;

    int currentIndex = 0;

    Vector2 poolPosition = new Vector2(0f, -25f);
    void Awake()
    {
        Floats = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Floats[i] = Instantiate(Prefab, poolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnLastTime + rateTime)
        {
            spawnLastTime = Time.time;
            rateTime = Random.Range(rateMin, rateMax);
            yPos = Random.Range(yPosMin, yPosMax);

            Floats[currentIndex].transform.position = new Vector2(xPos, yPos);

            Floats[currentIndex].SetActive(false);
            Floats[currentIndex].SetActive(true);

            currentIndex++;



            if (currentIndex >= count) currentIndex = 0;
        }
    }
}
