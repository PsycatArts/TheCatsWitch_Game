using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RelaxoCharmSpriteButton : MonoBehaviour, IPointerClickHandler,
                                  IPointerDownHandler/*, IPointerEnterHandler,*/
                                  //IPointerUpHandler, IPointerExitHandler
{


    //private Animation anim;
    private Animator anim;
    public GameObject buttonToDeactivate;

    void Start()
    {
        //Attach Physics2DRaycaster to the Camera
        // Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        anim = gameObject.GetComponent<Animator>();
        addEventSystem();
    }



    //mouse-finger down 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down!");
        //anim.Play("SpriteAn");
        AudioManager.PlaySound("SpriteButtonClickSound");

        Relaxo.Instance.MoveRelaxoOutOfWay();
        StartCoroutine(DeactivateButton());
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

    IEnumerator DeactivateButton()
    {
        yield return new WaitForSeconds(1);
        buttonToDeactivate.SetActive(false);


    }

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
    

