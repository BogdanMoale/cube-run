using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if(AudioManager.instance.isPlayingMusic == true)
        {
            AudioManager.instance.StopSound("MenuMusic");
        }
        
        if(AudioManager.instance.isPlayingGameOver == true)
        {
            AudioManager.instance.StopSound(AudioManager.songNameGameOver);
        }

        //FindObjectOfType<AudioManager>().PlaySound("Click");
        AudioManager.instance.PlaySound("Click");
        AudioManager.instance.PlayRandom(AudioManager.minMusicSound,AudioManager.maxMusicSound);
        SceneManager.LoadScene("Gameplay");
    }

    public void goToStore()
    {
        if(AudioManager.instance.isPlayingGameOver == true)
        {
            AudioManager.instance.StopSound(AudioManager.songNameGameOver);
        }

        if(AudioManager.instance.isPlayingMusic == false)
        {
            AudioManager.instance.PlaySound("MenuMusic");
        }

       AudioManager.instance.PlaySound("Click");
       SceneManager.LoadScene("Store");
    }

    public void goToLeaderboard()
    {
        
    }

    public void goToOptions()
    {
        if(AudioManager.instance.isPlayingGameOver == true)
        {
            AudioManager.instance.StopSound(AudioManager.songNameGameOver);
        }

        if(AudioManager.instance.isPlayingMusic == false)
        {
            AudioManager.instance.PlaySound("MenuMusic");
        }

        AudioManager.instance.PlaySound("Click");
        SceneManager.LoadScene("Options");
    }

    public void goToMenu()
    {
        if(AudioManager.instance.isPlayingGameOver == true)
        {
            AudioManager.instance.StopSound(AudioManager.songNameGameOver);
        }

        if(AudioManager.instance.isPlayingMusic == false)
        {
            AudioManager.instance.PlaySound("MenuMusic");
        }
        
        AudioManager.instance.PlaySound("Click");

        if(PlayerPrefs.GetFloat("musicVolume") > 0)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        else
        {
            AudioListener.volume = 1;
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void goToStoreBackground()
    {
        if(AudioManager.instance.isPlayingGameOver == true)
        {
            AudioManager.instance.StopSound(AudioManager.songNameGameOver);
        }

        if(AudioManager.instance.isPlayingMusic == false)
        {
            AudioManager.instance.PlaySound("MenuMusic");
        }

       AudioManager.instance.PlaySound("Click");
       SceneManager.LoadScene("StoreBackground");
    }
}
