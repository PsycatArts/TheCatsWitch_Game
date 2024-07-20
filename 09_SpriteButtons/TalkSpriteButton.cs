using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

public class TalkSpriteButton : MonoBehaviour, IPointerDownHandler
{

    //private Animator anim;
    

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        addEventSystem();
    }


    //On mouse/finger down  (when button is clicked..)
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        Debug.Log("Mouse Down: Access dialogue !");


        //first tutorial convo
        if (!DialogueManagerM.Instance.tutorialConvo_1)     //if first tutorial convo has not been triggered YET...
        {
            DialogueManager.StartConversation("D_1.4_Cat_StartDialogue");      //trigger dialogue tutorial
            DialogueManagerM.Instance.tutorialConvo_1 = true;                   //set bool flag true so it doesnt trigger again
            AudioManager.PlaySound("Cat_SFX_2");
            JournalBase.Instance.newQuestMarker.SetActive(true);
        }
        //Finding catnip ingredient
        if (DialogueManagerM.Instance.tutorialConvo_1 &&CollectManagerProvisoric.Instance.itemList[0].isCollected && !CollectManagerProvisoric.Instance.hasCharmPotion)       //if first tutorialConvo has been triggered already, and you have herb collected, and charm potion is NOT equipped..
        {
            DialogueManager.StartConversation("C_1.3_Cat_GoBrewing");      //triger dialogue to hint to brewing with herb
            AudioManager.PlaySound("Cat_SFX_1");
        }
        //brewing charm potion and activating it
        if (!DialogueManagerM.Instance.giveStrengthRecip_3 && M_Potion.Instance.hasCharmPotionActive)   //if strengthRecip not given yet, and charm potion is active..
        {
            DialogueManager.StartConversation("D_1.5_Cat_GetRecipeOfStrength");     //charm potion is brewed, getting strength recipie
            DialogueManagerM.Instance.giveStrengthRecip_3 = true;
            JournalBase.Instance.newQuestMarker.SetActive(true);

        }
        //finding raddish ingredient (third element in array)
        if (CollectManagerProvisoric.Instance.itemList[2].isCollected && !CollectManagerProvisoric.Instance.hasNightPotion  /*&& !DialogueManagerM.Instance.giveNightRecip_3*/)   //if raddish is found, no night potion yet and no night recip...
        {
            DialogueManager.StartConversation("D_3.3_Cat_GettingNightPotion");     //give recipie for night potion
            AudioManager.PlaySound("Cat_SFX_3");
            QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p5_doneImage);       //journal - finish task 5, talking about raddish
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p6);                  //journal - activate task 6
            DialogueManagerM.Instance.giveNightRecip_3 = true;
            JournalBase.Instance.newQuestMarker.SetActive(true);
            //DialogueManagerM.Instance.giveNightRecip_3 = true;
        }
        //if night potion brewed..
        if (CollectManagerProvisoric.Instance.hasNightPotion && !DialogueManagerM.Instance.goToBed_4 && !M_World.Instance.isNight)   //if night potion brewed, its not night and it has not been triggered yet..
        {
            DialogueManager.StartConversation("C_3.10_Cat_GoToBed");     //give recipie for night potion
            DialogueManagerM.Instance.goToBed_4 = true;

        }
        //if night potion brewed and its night for the first time
        if (M_World.Instance.isNight  &&  !DialogueManagerM.Instance.nightForFirstTime_4 )      //if its night and end dialogue has never been triggered yet...
        {
            DialogueManager.StartConversation("H_4.1_EndOfGame");
            DialogueManagerM.Instance.nightForFirstTime_4 = true;
            AudioManager.PlaySound("Cat_SFX_1");
        }


        //Do Something...
        // anim.Play("SpriteAn");
    }


    //Add Event System to the Camera
    void addEventSystem()
    {
        GameObject eventSystem = null;
        GameObject tempObj = GameObject.Find("EventSystem");
        if (tempObj == null)
        {
            eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else
        {
            if ((tempObj.GetComponent<EventSystem>()) == null)
            {
                tempObj.AddComponent<EventSystem>();
            }

            if ((tempObj.GetComponent<StandaloneInputModule>()) == null)
            {
                tempObj.AddComponent<StandaloneInputModule>();
            }
        }

    }
}
