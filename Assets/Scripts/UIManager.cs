using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverText;
    public Text highScoreText;
    public Text scoreText;


    float currentTime;

    bool highAchive =false;
    bool isDead = false;

    int highScore = 0;
    int score = 0;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "HIGH SCORE : " + highScore;
    }

    public void viewGameOverText()
    {
        isDead = true;
        currentTime = Time.time;
        gameOverText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {

            if (Time.time - currentTime >= 1)
            {
                if (Input.GetMouseButton(0))
                {
                    if (highAchive == true)
                    {
                        PlayerPrefs.SetInt("HighScore", highScore);
                    }


                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

        }
        else if (Time.time > currentTime + 2f)
        {
            currentTime = Time.time;
            OnAddScore(1);
        }
    }


    void highScoreAchieve()
    {
        highAchive=true;
        highScoreText.color = Color.red;
    }

    public void OnAddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "SCORE : " + score;

        if(score > highScore)
        {
            highScoreAchieve();
            highScore = score;
            highScoreText.text = "HIGH SCORE : " + score;
        }
    }

    
}
