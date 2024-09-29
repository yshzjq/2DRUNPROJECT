using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScrips : MonoBehaviour
{
    AudioSource coinaudio;
    Animator coinanimation;
    int sw = 0;

    void Start()
    {
        coinaudio = GetComponent<AudioSource>();
        coinanimation = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"&&sw == 0)
        {
            sw = 1;
            coinaudio.Play();
            coinanimation.SetTrigger("getCoin");
        }
    }
}