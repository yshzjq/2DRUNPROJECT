using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macdae : MonoBehaviour
{
    int sw = 0;
    Animator macdaeAni;
    Rigidbody2D macdaerigi;

    private void Start()
    {
        macdaeAni = GetComponent<Animator>();
        macdaerigi = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sw == 1) { return; }
        else if (collision.collider.tag == "Player")
        {
            Rigidbody2D prd = collision.transform.GetComponent<Rigidbody2D>();
            Animator pani = collision.transform.GetComponent<Animator>();
            sw = 1;
            if (HeartBarControll.instance.currentIndex > 0)
            {
                pani.SetTrigger("hitFrom");
                macdaerigi.AddForce(new Vector2(400f, 20f));
                macdaeAni.SetTrigger("macdae Die");
                

                Destroy(gameObject, 0.3f);
                prd.AddForce(new Vector2(-200f, 30f));
                HeartBarControll.instance.breakHeart();
            }
            else
            {
                HeartBarControll.instance.breakHeart();
            }
            
           
            return;
        }
    }
}
