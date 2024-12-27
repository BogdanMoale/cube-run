using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeEffects : MonoBehaviour
{
    [SerializeField] Slider effectsSlider;
    [SerializeField] TMP_Text effectsValue;
    public static float effectsVolume;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", 0.5f);
            effectsSlider.value = 0.5f;
            effectsValue.text = Mathf.RoundToInt(0.5f  * 100).ToString() + "%";
        }
        else
        {
            LoadEffectsVolume();
        }
    }

    public void ChangeVolumeEffects()
    {
        //AudioListener.volume = effectsSlider.value;
        effectsValue.text = Mathf.RoundToInt(effectsSlider.value * 100).ToString() + "%";
        SaveEffectsVolume();
    }

    private void LoadEffectsVolume()
    {
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume");
        effectsVolume = PlayerPrefs.GetFloat("effectsVolume");
        effectsValue.text = Mathf.RoundToInt(effectsVolume  * 100).ToString() + "%";

    }

    private void SaveEffectsVolume()
    {
        PlayerPrefs.SetFloat("effectsVolume", effectsSlider.value);
    }

    
}
