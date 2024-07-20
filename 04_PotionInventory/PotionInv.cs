using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionInv : MonoBehaviour
{

    public GameObject potionInventory;
    public GameObject activeSlot;
    public GameObject nightPotionSlot;
    public Sprite charm;
    public Sprite night;
    //public Sprite strength;
    //public Sprite combi;

    public M_Potion potionState;

    public static PotionInv Instance;

    public GameObject initialPotionInvButton;   //used in CollectManager to activate/deactivate the initial potionInvButton depending on if first potion was made

    public GameObject exchangeIcon;
    public GameObject exchangeHighlight;

    void Start()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);
        //charm= GetComponentInChildren<Image>().sprite;
        //night= GetComponentInChildren<Image>().sprite;
        //strength = GetComponentInChildren<Image>().sprite;


        
    }

    //Check which potion is equipped and change bool of fsm state to switch state (depending un which sprite is in active slot
    void Update()
    {
        //CHARM POTION
        if (activeSlot.GetComponentInChildren<Image>().sprite == charm)
        {
            M_Potion.Instance.hasCharmPotionActive = true;
            //potionState.hasCharmPotionActive = true;
        }
        else if (activeSlot.GetComponentInChildren<Image>().sprite != charm)
        {
            M_Potion.Instance.hasCharmPotionActive = false;
            //potionState.hasCharmPotionActive = true;
        }


        //NIGHT POTION
        if (activeSlot.GetComponentInChildren<Image>().sprite == night)
        {
            M_Potion.Instance.hasNightPotionActive = true;
            //Debug.Log("Current potion is night");
            //potionState.hasNightPotionActive = true;
        }
        else if (activeSlot.GetComponentInChildren<Image>().sprite != night)
        {
            M_Potion.Instance.hasNightPotionActive = false;
           // potionState.hasNightPotionActive = false;
        }

        //Strength POTION
        //if (activeSlot.GetComponentInChildren<Image>().sprite == strength)
        //{
        //   // Debug.Log("Current potion is strength");
        //}
        //if (activeSlot.GetComponentInChildren<Image>().sprite == combi)
        //{
        //    //Debug.Log("Current potion is combi");
        //}
    }

    public void SwapItems(GameObject pressed)
    {
        
        activeSlot.GetComponentInChildren<Image>().sprite = pressed.GetComponent<Image>().sprite;       //switch the sprites 
        //activeSlot/*.GetComponentInChildren<Image>().sprite*/ = pressed/*.GetComponentInChildren<Image>().sprite*/;
        

        //for (int i = 0; i < slots.Length; i++)
        //{
        //    tempPos = slots[i].transform.position;
        //    slots[i].transform.position = activeSlot.transform.position;
        //    activeSlot.transform.position = tempPos;
        //}
    }

    //expand bg bar of all potions on click
    public void OpenClosePotionInv()
    {
        if(CollectManagerProvisoric.Instance.hasNightPotion)        //only allow to open Potioninventory if the night potion is collected -otherwise default is charm only
        {
            if (!potionInventory.activeSelf)
            {
                exchangeHighlight.SetActive(true);
                potionInventory.SetActive(true);
                Debug.Log("Opening Potion Inventory");
            }
            else if (potionInventory.activeSelf)
            {
                exchangeHighlight.SetActive(false);
                potionInventory.SetActive(false);
                Debug.Log("Closing Potion Inventory");
            }
        }

    }


}
