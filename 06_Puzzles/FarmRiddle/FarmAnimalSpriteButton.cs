using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FarmAnimalSpriteButton :  MonoBehaviour, IPointerClickHandler,
                                  IPointerDownHandler/*, IPointerEnterHandler,*/
//IPointerUpHandler, IPointerExitHandler
{

    private Animal animal;
    private Animator anim;

    void Start()
    {
        animal = gameObject.GetComponentInParent<Animal>();
        anim = gameObject.GetComponent<Animator>();
        addEventSystem();
    }

    public void OnPointerDown(PointerEventData eventData)       //when charm button pressed..
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        Debug.Log("Mouse Down!");
        //anim.Play("SpriteAn");                                  //play button anim..
        animal.NegateFollow();
        //Frog.Instance.NegateFollow();


        //StartCoroutine(DeactivateButton());
    }
public void OnPointerClick(PointerEventData eventData)
{

    // Debug.Log("Mouse Clicked!");
}

//IEnumerator DeactivateButton()
//{
//    yield return new WaitForSeconds(1);
//    buttonToDeactivate.SetActive(false);


//}
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
