using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

/// <summary>
/// FARMER NPC TALK BUTTON AND LOGIC
/// </summary>
public class FarmerSpritebutton : MonoBehaviour, IPointerDownHandler
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

       // first quest convo
        if (!DialogueManagerM.Instance.riddleStart_1)     //if first quest convo has not been triggered YET...
        {
            DialogueManager.StartConversation("D_3.2_Farmer_RiddleStart");      //trigger dialogue 
            DialogueManagerM.Instance.riddleStart_1 = true;                   //set bool flag true so it doesnt trigger again
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p4);          //activate task 3 in journal
        }
        else if (DialogueManagerM.Instance.riddleStart_1 && !DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected)     //if first tutorial convo has been triggered
        {
            DialogueManager.StartConversation("C_3.2_Farmer_RepetitionBeeRiddle");      //trigger repetition of bee 
        }

        //if pressed on talk button when animal 1 was delivered but animal 2 still is NOT.. give repetition of riddle 2
        if (DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected && !DeliveryRiddle.Instance.animalToDeliver_02.animalScriptableObject.isCollected)    //if first animal is already collected and the second animal was NOT.. give easy hint for animal 2
        {
            DialogueManager.StartConversation("C_3.5_Farmer_RepetitionFrogRiddle");

        }
   


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
