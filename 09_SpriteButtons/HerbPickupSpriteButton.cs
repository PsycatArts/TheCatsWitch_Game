using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HerbPickupSpriteButton : MonoBehaviour, IPointerClickHandler,
                                  IPointerDownHandler/*, IPointerEnterHandler,*/
//IPointerUpHandler, IPointerExitHandler
{

    public ItemCollecterProvisoric herb;
    //private Animator anim;

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        addEventSystem();
    }

    //mouse-finger down 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down!");
        //herb.PickupHerb();
        this.gameObject.SetActive(false);
        // anim.Play("SpriteAn");
    }


    //}
    //mouse-finger up
    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Mouse Clicked!");
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