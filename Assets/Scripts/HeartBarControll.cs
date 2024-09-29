using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBarControll : MonoBehaviour
{
    public static HeartBarControll instance;
    public GameObject[] hearts;
    public Animator[] heartsAni;
    public int maxHeartCnt = 5;
    AudioSource hitfromAudio;
    int heartcnt;
    public int currentIndex = 2;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        heartsAni[3].SetTrigger("setNull");
        heartsAni[4].SetTrigger("setNull");

        hitfromAudio = GetComponent<AudioSource>();
    }
    public void getHeart()
    {
        if(currentIndex < 4)
        {
            currentIndex++;
            heartsAni[currentIndex].SetTrigger("heartGet");
        }
        else
        {
            UIManager.instance.OnAddScore(5);
        }
        
    }

    public void breakHeart()
    {
        if(currentIndex == 0)
        {
            PlayerController.instance.playerDie();
            heartsAni[currentIndex].SetTrigger("heartBreak");
            return;
        }
        else
        {
            hitfromAudio.Play();
            heartsAni[currentIndex].SetTrigger("heartBreak");
            currentIndex--;
        }
    }

}
