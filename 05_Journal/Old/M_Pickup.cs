using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the item Object that's laying in world to be picked up
/// Check if inventory is full, if not, instantiate its item button in the inventory
/// </summary>
public class M_Pickup : MonoBehaviour
{

    public M_Inventory matchingInv;
    public GameObject itemButton;                                   //the button prefab which will be instantiated in journal UI
    public int itemID;

    public bool isCollected;

    private void Start()
    {
        //matchingInv.GetComponent<M_PlayerInv>();                    //find player journal(inventory)
    }

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            AddItemToInv();
        }
    }

    void AddItemToInv()
    {
      
        
        for (int i = 0; i < matchingInv.slots.Length; i++)                          //go through all slots of inv[0]
        {
                if (matchingInv.IsFilled[i] == false)                               //if inventory spot is free, then..
                {
                    if (matchingInv.allowedItemID == itemID)                        //if allowedItemID is same as this picked up item ID..
                    {                                                               //item can be added to inv

                     matchingInv.IsFilled[i] = true;

                     Instantiate(itemButton, matchingInv.slots[i].transform, false); //create the itemButton and parent it to set spawn position (also set false not set in world coordinate but in UI)
                     Destroy(gameObject);

                    isCollected = true;


                     break;

                    }
                    
                }
        }
        
    }



}


