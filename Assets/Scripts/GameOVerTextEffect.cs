using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVerTextEffect : MonoBehaviour
{
    public AudioSource gameOverAudio;

    float ed = 10f;
    float effectTime = 0.3f;
    float startScriptTime;
    // Start is called before the first frame update
    void Start()
    {
        gameOverAudio.Play();
        
        startScriptTime = Time.time;
    }

    void Update()
    {

        if(Time.time - startScriptTime < effectTime)
        {
            transform.Translate(new Vector2(ed, -ed));
            ed *= -1;
        }
        else 
        { 
            return; 
        }

    }


}
