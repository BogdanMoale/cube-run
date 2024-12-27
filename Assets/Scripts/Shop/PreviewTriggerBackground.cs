using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class PreviewTriggerBackground : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image img;
    GameObject g;
    [SerializeField] Transform obj;
    [SerializeField] Transform ScrollShop;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        g=obj.GetChild(0).gameObject;
        img.sprite = g.transform.GetComponent<Image>().sprite;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
        g = ScrollShop.GetChild(0).gameObject;
        img.sprite = ShopBackground.instance.ShopItemsList[PlayerPrefs.GetInt("posImgB", 0)].Image;//Shop.selecteditemSprite;
    }
}
