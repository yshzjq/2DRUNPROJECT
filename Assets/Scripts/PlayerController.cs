using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    AudioSource playerAudio;

    public AudioClip deadClip;

    bool isDead = false;
    bool isGrounded = false;

    public float jump_Power = 6f;
    float currentTime;

    public int playerLife = 3;
    int jumpCount = 0;

    public int jumpMaxCnt = 2;
    private void Awake()
    {
        if(instance == null)
        {
        instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    public void playerToDie()
    {
        playerLife--;

    }

    public void playerDie()
    {
        isDead = true;

        playerAudio.clip = deadClip;
        playerAudio.Play();

        playerAnimator.SetTrigger("Die");

        GameManager.instance.isDead = true;
        UIManager.instance.viewGameOverText(); // UI매니저 플레이어 죽음 실행
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            return;
        }

        currentTime = Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && jumpCount < jumpMaxCnt)
        { // 점프 제한, 마우스 우클릭시 점프,점프 소리가 나게함
            if (jumpCount >= 1)
            {
                playerAnimator.SetTrigger("DoubleJump");
            }
            jumpCount++;
            
            playerAudio.Play();
            
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.velocity = new Vector2(0f,jump_Power);
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidBody.velocity.y > 0f)
        { // 마우스 우클릭 손에서 뗄떄 점프 높이 조절 
            playerRigidBody.velocity /= 2;
        }

        if(transform.position.x < -6.5f) 
        {
            transform.Translate(new Vector2(3f * Time.deltaTime, 0));

            if (transform.position.x < -9.5f)
            {
                transform.position = new Vector2(-9f,transform.position.y);
            }
        }
        else if(transform.position.x > -5.5f)
        {
            transform.Translate(new Vector2(-3f * Time.deltaTime, 0));

            if (transform.position.x > -2.5f)
            {
                transform.position = new Vector2(-2.8f, transform.position.y);
            }
        }

        playerAnimator.SetBool("Grounded", isGrounded);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (isDead == true)
        {
            return;
        }


        if(collision.tag == "Dead")
        {
            

            HeartBarControll.instance.breakHeart();

            if(GameManager.instance.isDead == true)
            {
                return;
            }

            playerAnimator.SetTrigger("hitFrom");

            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(new Vector2(0f, 1400f));

            jumpCount = 0;
        }

        if(collision.tag =="HeartObject")
        {
            HeartBarControll.instance.getHeart();
        }

        if(collision.tag == "Coin")
        {
            UIManager.instance.OnAddScore(1);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.8f)
        {
            jumpCount = 0;
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        playerRigidBody.velocity += new Vector2(0f, 1.5f);
    }
}
