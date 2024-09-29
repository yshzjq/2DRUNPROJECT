using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrollingObject : MonoBehaviour
{
   
    public float speed = 10f;

    private void Start()
    {
        speed = GameManager.instance.globalSpeed;
    }
    

    void Update()
    {
        if(GameManager.instance.isDead==true)
        {
            return;
        }

        transform.Translate(new Vector2(-speed * 0.8f * Time.deltaTime,0f));
    }
}
