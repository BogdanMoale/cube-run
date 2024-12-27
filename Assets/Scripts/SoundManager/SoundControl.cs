using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(AudioManager.isPlaying);
        if (AudioManager.instance.isPlayingMusic == false)
        {
            AudioManager.instance.PlaySound("MenuMusic");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
