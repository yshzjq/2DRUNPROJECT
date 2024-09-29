using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundBack : MonoBehaviour
{
    BoxCollider2D backGround;

    float width;
    void Start()
    {
        backGround = GetComponent<BoxCollider2D>();

        width = backGround.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -width)
        {
            transform.position = new Vector2(width, transform.position.y);
        }
    }
}
