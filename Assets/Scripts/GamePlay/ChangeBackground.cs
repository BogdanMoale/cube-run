using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ChangeBackground : MonoBehaviour
{
   private MeshRenderer backgroundRend;
   private Texture2D backgroundTexture;
   private Sprite backgroundSprite;

    void Awake()
    {
         backgroundRend = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        try
        {
            //convert image sprite from shop in 2D texture
            backgroundSprite = ShopBackground.instance.ShopItemsList[PlayerPrefs.GetInt("posImgB",0)].Image;
            backgroundTexture = backgroundSprite.texture;
            //set the texture to the background mesh renderer
            backgroundRend.material.mainTexture = backgroundTexture;

        }

        catch
        {
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
