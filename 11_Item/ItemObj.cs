using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public ItemScriptableObject itemScriptableObject;

    private GameObject pickupSpriteButton;

    private string itemType;
    private SpriteRenderer itemSprite;


    // Start is called before the first frame update
    void Start()
    {

        pickupSpriteButton = this.gameObject.transform.GetChild(0).gameObject;      //GET pickupspritebutton from first child obj
        pickupSpriteButton.SetActive(false);                                        //deactivate it


        itemSprite = this.gameObject.GetComponent<SpriteRenderer>();                //refference this spriterenderer component
        itemSprite.sprite = itemScriptableObject.itemSprite;                        //set ingame item sprite to scriptableobj sprite
        itemType = itemScriptableObject.itemType;                                       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            //PickupItem();
            pickupSpriteButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            pickupSpriteButton.SetActive(false);
            
        }
    }

    public void PickupItem()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        for (int i = 0; i < CollectManagerProvisoric.Instance.itemList.Length; i++)     //go through itemList
        {
            if (CollectManagerProvisoric.Instance.itemList[i].itemType == this.itemType)        //check if any itemType in there is same as THIS itemtype
            {
                CollectManagerProvisoric.Instance.itemList[i].isCollected = true;               //if yes, then set collected on that item to true
            }
        }
        this.gameObject.SetActive(false);
        //CollectManagerProvisoric.Instance.itemList[0].isCollected=true;
        // CollectManagerProvisoric.Instance.itemList[]
        //CollectManagerProvisoric.Instance.
        //CollectManagerProvisoric.Instance.hasCollectedHerbs = true;

        //Destroy(this.gameObject);
    }
}
