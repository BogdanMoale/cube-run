using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static int coins {get;set;}
    public static int currentCoins {get;set;}
    public TMP_Text TotalCoinsTextValue;
    public TMP_Text CurrentCoinsTextValue;
    private Scene currentScene;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        coins = int.Parse(AESHandler.AESDecryption(PlayerPrefs.GetString("money")));
        currentCoins = int.Parse(AESHandler.AESDecryption(PlayerPrefs.GetString("CurrentMoney")));

        if(TotalCoinsTextValue != null)
        {
            TotalCoinsTextValue.text = coins.ToString();
        }

        if(CurrentCoinsTextValue != null)
        {
            CurrentCoinsTextValue.text = currentCoins.ToString();
        }
        
    }

    void Update()
    {
         if (currentScene.name == "Store" || currentScene.name == "StoreBackground")
         {
            coins = int.Parse(AESHandler.AESDecryption(PlayerPrefs.GetString("money")));
            TotalCoinsTextValue.text = coins.ToString();

         }
    }
   
   public void GameOver()
   {
        if(AudioManager.instance.isPlayingMusic == true)
        {
            AudioManager.instance.StopSound(AudioManager.songName);
        }
        Invoke("RestartAfterTime",1f);
   }

   void RestartAfterTime()
   {
        PlayerPrefs.SetString("money", AESHandler.AESEncryption(coins.ToString()));
        PlayerPrefs.SetString("CurrentMoney", AESHandler.AESEncryption(currentCoins.ToString()));
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
   }

   public void increaseCoins()
   {
        coins = coins + 1;
        currentCoins = currentCoins +1;
   }


}
