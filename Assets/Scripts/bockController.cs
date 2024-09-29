using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bockController : MonoBehaviour
{
    public BoxCollider2D attack;
    public BoxCollider2D search;
    Animator bokanimate;
    int sw;

    Rigidbody2D bockRigidbody;
    void Start()
    {
        sw = 0;
        attack = GetComponent<BoxCollider2D>();
        search = GetComponent<BoxCollider2D>(); 
        bockRigidbody = GetComponent<Rigidbody2D>();
        bokanimate = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && sw == 0)
        {
            sw = 1;
            bockRigidbody.AddForce(new Vector2(-600f, 100f));
            bokanimate.SetTrigger("attack");
           // bokanimate.SetTrigger("idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            HeartBarControll.instance.breakHeart();
        }
       
    }
}
