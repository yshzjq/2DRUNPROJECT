using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float globalSpeed = 10f;

    public int playerHp = 3;

    public bool isDead = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playerDie()
    {
        isDead = true;
        globalSpeed = 0f;
    }
}
