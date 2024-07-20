using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FrogCharmSpriteButton : MonoBehaviour, IPointerDownHandler
{

    public Frog frog;
    
   // private Animator anim;

    void Start()
    {
       // anim = gameObject.GetComponent<Animator>();
        addEventSystem();
    }

    public void OnPointerDown(PointerEventData eventData)       //when charm button pressed..
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        Debug.Log("Mouse Down!");   
       // anim.Play("SpriteAn");                                  //play button anim..
        frog.NegateFollow();
    }


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