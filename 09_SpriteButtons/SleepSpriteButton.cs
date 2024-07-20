using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class SleepSpriteButton : MonoBehaviour, IPointerClickHandler,
                                  IPointerDownHandler/*, IPointerEnterHandler,*/
//IPointerUpHandler, IPointerExitHandler
{
    //public GameObject panel;

    //private Animation anim;
    //private Animator anim;
    //public GameObject buttonToDeactivate;

    

    void Start()
    {
    //Attach Physics2DRaycaster to the Camera
    // Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
    //anim = gameObject.GetComponent<Animator>();
    addEventSystem();

       
    }

    void Update()
    {
        // DialogueManager.instance.conversationEnded += panel.SetActive(false);
        if (DialogueManager.currentConversationState == null)   //if there is no conversation going on
        {
            if (PauseMenu.Instance.tooDarkPanel.activeSelf)       //if the panel is active
            {
                PauseMenu.Instance.tooDarkPanel.SetActive(false);       //set it to false
            }
        }
    }


//mouse-finger down 
public void OnPointerDown(PointerEventData eventData)
{
    Debug.Log("Mouse Down!");
        //anim.Play("SleepSpriteButtonAnimation");
        AudioManager.PlaySound("SpriteButtonClickSound");
        SleepAndChangeState();
   // Relaxo.Instance.MoveRelaxoOutOfWay();
   // StartCoroutine(DeactivateButton());
    }
public void DestroySpriteButton()
{
    Destroy(this.gameObject);
}

//mouse-finger up
public void OnPointerClick(PointerEventData eventData)
{

    // Debug.Log("Mouse Clicked!");
}

//IEnumerator DeactivateButton()
//{
//    yield return new WaitForSeconds(1);
//    buttonToDeactivate.SetActive(false);


//}

    public void SleepAndChangeState()
    {
        Debug.Log("Pressing switch button");
        if (M_Potion.Instance.hasNightPotionActive)       //if Night potion is active....
        {
            //change world state
            if (!M_World.Instance.isNight)                 //if its day
            {
                M_World.Instance.isNight = true;          //set key bool isNight true - to activate night
            }
            else if(M_World.Instance.isNight)
            {
                M_World.Instance.isNight = false;        //set key bool isNight false - to activate day
            }
            M_World.Instance.SeeForChange();            //switch the state depending on key bool
        }
        else if (!M_Potion.Instance.hasNightPotionActive)
        {
            //panel.SetActive(true);
            PauseMenu.Instance.tooDarkPanel.SetActive(true);
            DialogueManager.StartConversation("D_1.1_Cat_CantSeeInDark");     //trigger dialogue of cat
            Debug.Log("I can not sleep because i have no night potion active");
        }
    }
    

    //IEnumerator SleepPanel()
    //{
    //    yield return new WaitForSeconds(1);
    //    buttonToDeactivate.SetActive(false);


    //}


    ////when mouse is hovering over the sprite hitbox
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("Mouse Enter!");
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Debug.Log("Mouse Up!");
    //}
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("Mouse Exit!");
    //}

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
