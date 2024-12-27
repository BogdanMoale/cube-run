using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float moveSpeed = 2f;
    private float screenCenterX;
    

    
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        //reset current coins value
        PlayerPrefs.SetString("CurrentMoney",AESHandler.AESEncryption("0"));
    }

    void Start()
    {
        // save the horizontal center of the screen
        screenCenterX = Screen.width * 0.5f;
        
    }

    
    void FixedUpdate()
    {
        MoveTouch();
    }

    //move player from keyboard(A D key or Right Arrow Left Arrow Key)
    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            playerBody.velocity = new Vector2(moveSpeed,playerBody.velocity.y);
        }

        if(Input.GetAxisRaw("Horizontal") < 0f)
        {
            playerBody.velocity = new Vector2(-moveSpeed,playerBody.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        playerBody.velocity = new Vector2(x,playerBody.velocity.y);
    }

    
    //move player by touching screen(left side to move left, right side to mive right)
    void MoveTouch()
    {
        // if there are any touches currently
        if(Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);
            
            // if it began this frame
            if(firstTouch.phase == TouchPhase.Stationary)
            {
                if(firstTouch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right
                     playerBody.velocity = new Vector2(moveSpeed,playerBody.velocity.y);
                }
                else if(firstTouch.position.x < screenCenterX)
                {
                    // if the touch position is to the left of center
                    // move left
                     playerBody.velocity = new Vector2(-moveSpeed,playerBody.velocity.y);
                }
            }

            if(firstTouch.phase == TouchPhase.Ended)
            {
                playerBody.velocity = new Vector2(0,playerBody.velocity.y);
            }
            
        }
    }

}
