using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    #region SIngleton:Game
    public static Game Instance;
    void Awake()
    {
        decrypted_Coins =AESHandler.AESDecryption(PlayerPrefs.GetString("money"));
        Coins =int.Parse(decrypted_Coins);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int Coins;
    private string decrypted_Coins;
    private string encrypted_Coins;
   
    

    public void UseCoins(int amount)
    {
        Coins -= amount;
        encrypted_Coins = Coins.ToString();
        PlayerPrefs.SetString("money",AESHandler.AESEncryption(encrypted_Coins));
        //PlayerPrefs.SetInt("money",Coins);
    }

    public bool HasEnoughCoins(int amount)
    {
        return (Coins >= amount);
    }

    void Update()
    {
        decrypted_Coins =AESHandler.AESDecryption(PlayerPrefs.GetString("money"));
        Coins =int.Parse(decrypted_Coins);
        //Coins = PlayerPrefs.GetInt("money");
    }
}
