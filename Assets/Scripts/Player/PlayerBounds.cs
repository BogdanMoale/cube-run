using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public float min_X = -2.6f, max_X=2.6f, min_Y=-5.6f;
    private bool outOfBounds;

    // Update is called once per frame

    void Start()
    {
        //get screen edges
        min_X = CameraEdges.PlayerLeftTop.x;
        max_X = CameraEdges.PlayerRightTop.x;
        
        //Debug.Log("Player Bound lef: " + min_X.ToString());
        //Debug.Log("Player Bound right: " + max_X.ToString());
    }
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if(temp.x > max_X)
        {
            temp.x = max_X;
        }

        if(temp.x < min_X)
        {
            temp.x = min_X;
        }

        transform.position = temp;

        if(temp.y <= min_Y)
        {
            if(!outOfBounds)
            {
                outOfBounds = true;
                AudioManager.instance.PlaySound("Death");
                GameManager.instance.GameOver();
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            AudioManager.instance.PlaySound("Death");
            GameManager.instance.GameOver();
            
        }
    }
}
