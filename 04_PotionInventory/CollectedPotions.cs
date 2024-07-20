using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPotions : MonoBehaviour
{
    public GameObject charmPotion;
    public GameObject nightPotion;
    public GameObject strengthPotion;
    //public GameObject combiPotion;

    public M_Inventory charmPotionInv;
    public M_Inventory nightPotionInv;
    public M_Inventory strengthPotionInv;

    //public M_Pickup charmP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < charmPotionInv.IsFilled.Length; i++)
        {
            if (charmPotionInv.IsFilled[i])
            {
                Debug.Log("charm potion is collected, bool true");
            }
        }
        
        //for (int i = 0; i < charmPotionInv.slots.Length; i++)                          //go through all slots of inv[0]
        //{
        //    if (charmPotionInv.IsFilled[i] == true)                               //if inventory spot is free, then..
        //    {
                
        //            Instantiate(charmPotion, matchingInv.slots[i].transform, false); //create the itemButton and parent it to set spawn position (also set false not set in world coordinate but in UI)
                    

        //    }
        //}



    }
}
