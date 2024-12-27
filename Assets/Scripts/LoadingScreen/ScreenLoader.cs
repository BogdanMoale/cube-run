using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScreenLoader : MonoBehaviour
{

  public GameObject loadingScreen;
  public Slider slider;
  public TMP_Text progressText;
  
   
  
   public void Start()
    {
        //create or set all necesarry player prefs
        createPlayerPrefsOptions();
        createPlayerPrefsMoney();
        setPlayerPrefsCurrentMoney();

        //wait some seconds
        StartCoroutine(Initialize());

        
    }

    public void LoadScreen(int sceneIndex)
    {
       StartCoroutine(LoadAsynchronously(sceneIndex));  
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
         
         AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
         
         loadingScreen.SetActive(true);

         while(!operation.isDone)
         {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            float smoothingSpeed = 0.1f;
            slider.value = Mathf.Lerp(slider.value, progress, Time.deltaTime * smoothingSpeed);
            progressText.text = Mathf.RoundToInt(progress * 100) + "%";
            yield return null;
         }
    }

    IEnumerator Initialize()
    {
     
        yield return new WaitForSecondsRealtime(3f);
        //load store
        AsyncOperation sceneStore = SceneManager.LoadSceneAsync("Store", LoadSceneMode.Additive);
        sceneStore.allowSceneActivation = false;

        //load stor backgrounds
        AsyncOperation sceneStoreBackground = SceneManager.LoadSceneAsync("StoreBackground", LoadSceneMode.Additive);
        sceneStoreBackground.allowSceneActivation = false;

        //load menu
        //AsyncOperation sceneMenu = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        //sceneMenu.allowSceneActivation = false;

        //load options
        AsyncOperation sceneOptions = SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
        sceneOptions.allowSceneActivation = false;

        LoadScreen(1);
        
        sceneStore.allowSceneActivation = true;
        sceneOptions.allowSceneActivation = true;
        sceneStoreBackground.allowSceneActivation = true;
        //sceneMenu.allowSceneActivation = true;

        //IAP initialize
        //IAPManager.Instance.InitializeIAP();


    }

    void createPlayerPrefsOptions()
    {
        if(!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", 0.5f);
        }

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
        }
    }

    void createPlayerPrefsMoney()
    {
        if(!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetString("money",AESHandler.AESEncryption("0"));
        }
    }

    void setPlayerPrefsCurrentMoney()
    {
        PlayerPrefs.SetString("CurrentMoney",AESHandler.AESEncryption("0"));
    }

}
