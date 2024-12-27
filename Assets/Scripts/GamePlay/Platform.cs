using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform, is_Coin, is_Enemy;

    private Animator anim;
    

    void Awake()
    {
        if(is_Breakable)
        {
            anim = GetComponent<Animator>();
        }
        
    }
   
     // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y>bound_Y)
        {
            Destroy(gameObject);
        } 
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject",0.4f);
    }

    void DeactivateGameObject()
    {
        //SoundManager.instance.IceBreakSound();
        AudioManager.instance.PlaySound("IceBreak");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Player")
        {
            //spike
            if(is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                //SoundManager.instance.GameOverSound();
                AudioManager.instance.PlayRandomGameOver(AudioManager.minGameOverSound,AudioManager.maxGameOverSound);
                GameManager.instance.GameOver();
            }

            //coin
            if(is_Coin)
            {
                GameManager.instance.increaseCoins();
                Destroy(gameObject);
            }

            //enemy
            if(is_Enemy)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                //SoundManager.instance.GameOverSound();
                AudioManager.instance.PlayRandomGameOver(AudioManager.minGameOverSound,AudioManager.maxGameOverSound);
                GameManager.instance.GameOver();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if(is_Breakable)
            {
                //SoundManager.instance.LandSound();
                AudioManager.instance.PlaySound("Land");
                anim.Play("Break");
            }

            if(is_Platform)
            {
                //SoundManager.instance.LandSound();
                AudioManager.instance.PlaySound("Land");
            }

        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if(moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if(moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }

}
