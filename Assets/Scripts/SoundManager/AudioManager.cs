using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //for generating random song name
    public static int songNumber{set; get;}
    public static string songName{set; get;}

    //for generating random game over sounds name
    public static int songNumberGameOver{set; get;}
    public static string songNameGameOver{set; get;}

    public bool isPlayingMusic;
    public bool isPlayingGameOver;

    public static AudioManager instance;

    public static int minMusicSound {set;get;}
    public static int maxMusicSound {set;get;}

    public static int minGameOverSound {set;get;}
    public static int maxGameOverSound {set;get;}

    // Start is called before the first frame update
    void Awake()
    {
        isPlayingMusic = false;
        isPlayingGameOver = false;
        //to ensure that always will be just an instance of AudioManager
        if (instance == null)
        {
            instance = this;
            //Return a random int within [minInclusive..maxExclusive)
            minMusicSound = 1;
            maxMusicSound = sounds.Length + 1 - 6; //6 is the number of effects sounds

            minGameOverSound = 1;
            maxGameOverSound = 1;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //adding audio source for each sound in list
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    
    //playing sound
    public void PlaySound (string name)
    {
        //looking in array and find song name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("(Play)Sound: " + name +" not found!");
            return;
        }

        //checking if i have volumes saved in playerprefs

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            s.source.volume = 0.5f;
        }

        if(!PlayerPrefs.HasKey("effectsVolume"))
        {
            s.source.volume = 0.5f;
        }

        //background music
        if(name.Contains("Music"))
        {
            s.source.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        //effects music
        if(name.Contains("GameOver"))
        {
            s.source.volume = PlayerPrefs.GetFloat("effectsVolume");
        }

        if(name.Contains("Death"))
        {
            s.source.volume = PlayerPrefs.GetFloat("effectsVolume");
        }

        if(name.Contains("Click"))
        {
            s.source.volume = PlayerPrefs.GetFloat("effectsVolume");
        }

        if(name.Contains("IceBreak"))
        {
            s.source.volume = PlayerPrefs.GetFloat("effectsVolume");
        }

        if(name.Contains("Land"))
        {
            s.source.volume = PlayerPrefs.GetFloat("effectsVolume");
        }

        s.source.Play();

        if(name.Contains("Music"))
        {
            //Debug.Log("isPlayingMusic = true");
            isPlayingMusic = true;
        }

        if(name.Contains("GameOver"))
        {
            //Debug.Log("isPlayingGameOver = true");
            isPlayingGameOver = true;
        }
        
    }

    //stoping sound
    public void StopSound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("(Stop)Sound: " + name +" not found!");
            return;
        }

        if(name.Contains("Music"))
        {
            //Debug.Log("isPlayingMusic = false");
            isPlayingMusic = false;
        }

        if(name.Contains("GameOver"))
        {
            //Debug.Log("isPlayingGameOver = false");
            isPlayingGameOver = false;
        }
        

        //s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        //s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));
        s.source.Stop();
    }


    //play a random sound using PlaySound function
    public void PlayRandom(int min, int max)
    {
        songNumber = UnityEngine.Random.Range(min, max);
        songName = "Music" + songNumber.ToString();
        PlaySound(songName);

    }

    //play random sound when die
    public void PlayRandomGameOver(int min, int max)
    {
        songNumberGameOver = UnityEngine.Random.Range(min, max);
        songNameGameOver = "GameOver" + songNumberGameOver.ToString();
        PlaySound(songNameGameOver);
        
    }

    public void playClick()
    {
        PlaySound("Click");
    }

}
