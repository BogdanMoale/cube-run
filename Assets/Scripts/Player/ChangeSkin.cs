using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private BoxCollider2D playerBoxCollider;
    public GameObject currentPlayer;
    private GameObject animatedPlayer;
    public GameObject[] animatedPlayersPrefab;
    private Vector3 playerPosition;



    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        //get the current position of the player
        playerPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            //animated skin position 22 on skins list
            if(PlayerPrefs.GetInt("posImg",0)==22)
            {
                currentPlayer.SetActive(false);
                animatedPlayer=Instantiate(animatedPlayersPrefab[0],playerPosition,Quaternion.identity);
                Vector2 skinSize = spriteRenderer.sprite.rect.size/100f;
                playerBoxCollider.size = new Vector2(skinSize.x, skinSize.y);
            }
            else
            {
                spriteRenderer.sprite = Shop.instance.ShopItemsList[PlayerPrefs.GetInt("posImg",0)].Image;
                // change player box colider 2D size based on the selected skin
                Vector2 skinSize = spriteRenderer.sprite.rect.size/100f;
                //Debug.Log("Skin Size X: "+ (skinSize.x-0.1f).ToString());
                //Debug.Log("Skin Size Y: " + (skinSize.y-0.1f).ToString());
                playerBoxCollider.size = new Vector2(skinSize.x, skinSize.y);
            }
        }

        catch
        {

        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
