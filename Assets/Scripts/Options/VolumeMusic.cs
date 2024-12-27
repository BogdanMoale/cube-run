using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeMusic : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] TMP_Text musicValue;
    public static float musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            musicSlider.value = 0.5f;
            musicValue.text = Mathf.RoundToInt(0.5f  * 100).ToString() + "%";
        }
        else
        {
            LoadVolumeMusic();
        }
    }
    
    void Update()
    {
      
    }

    public void ChangeVolumeMusic()
    {
        
        AudioListener.volume = musicSlider.value;
        musicValue.text = Mathf.RoundToInt(musicSlider.value * 100).ToString() + "%";
        if(musicSlider.value == 0f)
        {
            AudioManager.instance.StopSound("MenuMusic");
        }

        
        SaveVolumeMusic();
    }

    private void LoadVolumeMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        musicValue.text = Mathf.RoundToInt(musicVolume  * 100).ToString() + "%";

    }

    private void SaveVolumeMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    
}
