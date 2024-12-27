using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraEdges : MonoBehaviour
{   
    public static Vector2 PlayerLeftBotom {get;set;}
    public static Vector2 PlayerLeftTop {get;set;}
    public static Vector2 PlayerRightTop {get;set;}
    public static Vector2 PlayerRightBottom{get;set;}

    //public static CameraEdges instance;

    private void Awake()
    {
        AddColliderOnCamera();
    }

    public void AddColliderOnCamera()
    {
        if(Camera.main == null)
        {
            Debug.Log("No Camera found!");
            return;
        }

        Camera cam = Camera.main;

        if(!cam.orthographic)
        {
            Debug.Log("Set the camera to orthographic");
            return;
        }

        //get or add edge collider 2d component
         var edgeColider = gameObject.GetComponent<EdgeCollider2D>() == null? gameObject.AddComponent<EdgeCollider2D>(): gameObject.GetComponent<EdgeCollider2D>();

         //make camera bounds
         PlayerLeftBotom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0,0,cam.nearClipPlane));
         PlayerLeftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0,cam.pixelHeight,cam.nearClipPlane));
         PlayerRightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth,cam.pixelHeight,cam.nearClipPlane));
         PlayerRightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth,0,cam.nearClipPlane));

         var edgePoints = new [] {PlayerLeftBotom, PlayerLeftTop, PlayerRightTop, PlayerRightBottom};

         edgeColider.points = edgePoints;

         Destroy (edgeColider);

         //Debug.Log("LeftBottom X :" + (PlayerLeftBotom.x).ToString());
         //Debug.Log("LeftTop X :" + (PlayerLeftTop.x).ToString());
         //Debug.Log("RightTop X :" + (PlayerRightTop.x).ToString());
         //Debug.Log("RightBottom X :" + (PlayerRightBottom.x).ToString());

    
    }
}