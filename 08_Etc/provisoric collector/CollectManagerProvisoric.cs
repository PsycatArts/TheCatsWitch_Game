using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to hold info if item/potion is collected to show/hide potionInventory
/// </summary>
public class CollectManagerProvisoric : MonoBehaviour
{
    public bool hasCharmPotion;
    public bool hasNightPotion;

    public static CollectManagerProvisoric Instance;


    public ItemScriptableObject[] itemList;     //holds items and their "has Collected" variable


    // Start is called before the first frame update
    void Start()
    {
         //= GameObject.FindGameObjectWithTag("PotionInventory");
       

        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if we have charm potion, activate whole potion INv
        if (!hasCharmPotion)
        {
            PotionInv.Instance.initialPotionInvButton.SetActive(false);
           // potionInvObj.SetActive(false);
        }
        else if (hasCharmPotion)
        {
            PotionInv.Instance.initialPotionInvButton.SetActive(true);

            QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p2_doneImage);           //journal - finish task 2
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p3);

            CharmPage_2.Instance.ChangeImagePotion();
            //CharmPage_2.Instance.charmPotionImage.GetComponent<Image>().color = new Color(255, 255, 255);

            //potionInvObj.SetActive(true);
        }


        //if we have night potion, activate the night potion button 
        if (!hasNightPotion)
        {
            PotionInv.Instance.exchangeIcon.SetActive(false);
            PotionInv.Instance.nightPotionSlot.SetActive(false);
            // potionInvObj.SetActive(false);
        }
        else if (hasNightPotion)
        {
            PotionInv.Instance.exchangeIcon.SetActive(true);
            PotionInv.Instance.nightPotionSlot.SetActive(true);

            QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p6_doneImage);

            NightPage3.Instance.ChangeImagePotion();
            //NightPage3.Instance.nightPotionImage.GetComponent<Image>().color = new Color(255, 255, 255);
            //PotionInv.Instance.nightPotionCover.SetActive(false);
            //potionInvObj.SetActive(true);
        }



        //for the journal

        //if herb collected
        if (itemList[0].isCollected)
        {
            QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p1_doneImage);       //finish task 1
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p2);                  //activate task 2
            //CharmPage_2.Instance.ingredientHerb1Image.GetComponent<Image>().color = new Color(255, 255, 255);
            CharmPage_2.Instance.ChangeImageIngredient();

            NightPage3.Instance.ChangeImageIngredient1();
            //NightPage3.Instance.ingredientHerb1Image.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        //spinach
        if (itemList[1].isCollected)
        {
            QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p3_doneImage);       //finish task 2
            StrengthPage4.Instance.ChangeImageIngredient3();
                            
        }
        //raddish
        if (itemList[2].isCollected)
        {
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p5);       //finish task 2
            NightPage3.Instance.ChangeImageIngredient2();
            //NightPage3.Instance.ingredientRaddish2Image.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        
    }
}
