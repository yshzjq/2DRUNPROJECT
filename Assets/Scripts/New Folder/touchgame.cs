using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


class touchgame : MonoBehaviour
{
    float clickTime;
    int sw = 0;
    public AudioSource ad1;
    public AudioSource ad2;
    void start()
    {
        ad1 = GetComponent<AudioSource>();
        ad2 = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) && sw ==0)
        {
            ad1.Stop();
            ad2.Play();
            clickTime = Time.time + 2f;
            sw = 1;
        }

        if(sw == 1 && clickTime < Time.time)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


}
