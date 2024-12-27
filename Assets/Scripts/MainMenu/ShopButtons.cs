using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    public Button skinShopButton;
    public Button backgroundShopButton;
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Store")
        {
            backgroundShopButton.interactable = true;
            skinShopButton.interactable = false;
        }

        if (currentScene.name == "StoreBackground")
        {
            backgroundShopButton.interactable = false;
            skinShopButton.interactable = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
