using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.Purchasing;
//using GleyInternetAvailability;
using UnityEngine.SceneManagement;

public class ShopBackground : MonoBehaviour
{
    public Image img;
    //public static int nr_select;
    //public static Sprite selecteditemSprite;

    [SerializeField] Sprite iconCoin;
    [SerializeField] Sprite iconDollar;
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Transform ShopScrollView;

    [System.Serializable] public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
        public bool realMoney = false;
    }

    [SerializeField] public List<ShopItem> ShopItemsList;
    
    GameObject ItemTemplate;
    GameObject g;

    Button buyBtn;

    
    //char[] c = new char[Shop.instance.ShopItemsList.Count]; //evidenta ce este cumparat
    char[] c = new char[1000]; //evidenta ce este cumparat

    
    public static ShopBackground instance;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
        c = new char[ShopBackground.instance.ShopItemsList.Count];
    }

    // Start is called before the first frame update
    public void Start()
    {
        

        //initializat cu zero
        for (int i=0;i< c.Length; i++)
        {
            c[i] = '0';
        }

        //read shopsettings
        string ssb = PlayerPrefs.GetString("ssb", "0");
        //adaugat in var temporala din vo din ssb
        for (int i = 0; i < ssb.Length; i++)
        {
            c[i] = ssb[i];
        }
        

        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        for (int i = 0; i < ShopItemsList.Count; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetComponent<TMP_Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            ShopItemsList[i].IsPurchased = c[i] == '1';// ShopItemsList[i].IsPurchased = c[i]== 1 ? true : false;

            //if skins is with real money show dollar icon for currency icon
            //else show coin icon

            if(ShopItemsList[i].realMoney)
            {
                g.transform.GetChild(3).GetComponent<Image>().sprite = iconDollar;
            }
            else
            {
                g.transform.GetChild(3).GetComponent<Image>().sprite = iconCoin;
            }

            ///----
            
            buyBtn.interactable = !ShopItemsList[i].IsPurchased;
            if (i == PlayerPrefs.GetInt("posImgB", 0))
            {
                buyBtn.interactable = false;
                img.sprite = ShopItemsList[i].Image;
                //selecteditemSprite = ShopItemsList[i].Image;
                buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            }
            else
            {
                buyBtn.interactable = true;
                
                buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text = c[i] == '1' ? "Select" : "Buy";
            }
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);

        }
        Destroy(ItemTemplate);


    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();

        if (buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text == "Select")
        {
            FindObjectOfType<AudioManager>().PlaySound("Click");
            img.sprite = ShopItemsList[itemIndex].Image;
            //selecteditemSprite = ShopItemsList[itemIndex].Image;
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = false;

            //activate previews select
            buyBtn = ShopScrollView.GetChild(PlayerPrefs.GetInt("posImgB",0)).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = true;
            //new inactive nr in list
            PlayerPrefs.SetInt("posImgB", itemIndex);//nr_select = itemIndex;
        }
        else
        {
            //buy with coins
            if (Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price) == true && 
            buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text == "Buy" && 
            ShopItemsList[itemIndex].realMoney !=true)
            {
                FindObjectOfType<AudioManager>().PlaySound("Click");
                Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
                Debug.Log(itemIndex);
                //Purchase Item
                ShopItemsList[itemIndex].IsPurchased = true;
                c[itemIndex] = '1';
                PlayerPrefs.SetString("ssb", new string(c));

                //disable the button
                buyBtn.interactable = false;
                buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";

                //Add image to avatar
                img.sprite = ShopItemsList[itemIndex].Image;
                //selecteditemSprite = ShopItemsList[itemIndex].Image;

                //activate previews select
                buyBtn = ShopScrollView.GetChild(PlayerPrefs.GetInt("posImgB", 0)).GetChild(2).GetComponent<Button>();
                buyBtn.interactable = true;
                //new inactive nr in list
                PlayerPrefs.SetInt("posImgB", itemIndex);//nr_select = itemIndex;

                //if(CloudSaveManagerJson.isPlayerLoggedIn==true)
                //{
                    //CloudSaveManagerJson.instance.SavePlayerDataCloud();
                //}
                
            }
            else if(ShopItemsList[itemIndex].realMoney !=true)
            {
                FindObjectOfType<AudioManager>().PlaySound("Click");
                //NoCoinsAnim.SetTrigger("NoCoins");
                Debug.Log("You don't have enough coins!!");
            }

            
            else if(ShopItemsList[itemIndex].realMoney == true)
            {
                FindObjectOfType<AudioManager>().PlaySound("Click");
                // //check if user have internet active when pressing buy
                // //check if user have a working internet connection when pressing buy 

                // //buy with real money
                // IAPManager.Instance.InitializeIAP();
                

                // if (IAPManager.Instance != null && IAPManager.Instance.IsInitialized())
                // //Check if the IAP system is initialized
                // {
                //     // Initiate the IAP purchase
                //     Debug.Log("enter pay");
                //     IAPManager.Instance.PurchaseItem(itemIndex);

                //     StartCoroutine(WaitForPurchaseOutcome(itemIndex));
                    
                // }
                // else
                // {
                //     Debug.Log("IAP not initialized.");
                // }

            }
        }
        
        
    }
    /*----------------------shop coins UI---------------------*/

    // private IEnumerator WaitForPurchaseOutcome(int itemIndex)
    // {
    //     while (true)
    //     {
    //         // Check the purchase outcome set in the IAPManager

    //         if (IAPManager.Instance.GetPaymentOutcome() == 1)
    //         {
    //             Debug.Log("return 1 - true");

    //             //cand v a fi implementat atunci si liniile urmatoare decomentata

    //             //Purchase Item
    //             ShopItemsList[itemIndex].IsPurchased = true;
    //             c[itemIndex] = '1';
    //             PlayerPrefs.SetString("ssb", new string(c));

    //             //disable the button
    //             buyBtn.interactable = false;
    //             buyBtn.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";

    //             //Add image to avatar
    //             img.sprite = ShopItemsList[itemIndex].Image;
    //             //selecteditemSprite = ShopItemsList[itemIndex].Image;

    //             //activate previews select
    //             buyBtn = ShopScrollView.GetChild(PlayerPrefs.GetInt("posImgB", 0)).GetChild(2).GetComponent<Button>();
    //             buyBtn.interactable = true;
    //             //new inactive nr in list
    //             PlayerPrefs.SetInt("posImgB", itemIndex);//nr_select = itemIndex;
    //             //cloud save
    //             if (CloudSaveManagerJson.isPlayerLoggedIn == true)
    //             {
    //                 CloudSaveManagerJson.instance.SavePlayerDataCloud();
    //             }


    //             //reset the outcome
    //             IAPManager.Instance.SetPaymentOutcome(0);
    //             break;
    //         }
    //         else if (IAPManager.Instance.GetPaymentOutcome() == 2)
    //         {
    //             Debug.Log("return 2 - false");

    //             //reset the outcome
    //             IAPManager.Instance.SetPaymentOutcome(0);
    //             break;
    //         }
    //         else
    //             Debug.Log("return 0 - not updated yet");


    //         yield return null; // Wait for a frame

    //     }
        
    // }
}
