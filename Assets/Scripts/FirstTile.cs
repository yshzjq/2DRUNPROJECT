using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private void Start()
    {
        speed = GameManager.instance.globalSpeed;

        Destroy(gameObject,5f);
    }


    void Update()
    {
        transform.Translate(new Vector2(-speed * 0.8f * Time.deltaTime, 0f));
    }
}
