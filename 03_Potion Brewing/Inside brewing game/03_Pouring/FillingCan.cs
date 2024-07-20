using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class FillingCan : MonoBehaviour, IPointerClickHandler,
                                  IPointerDownHandler/*, IPointerEnterHandler*/
//IPointerUpHandler, IPointerExitHandler
{

    public UI_Bar_Step3 canvas;


    //private Animation anim;
    [HideInInspector]public Animator anim;
    public GameObject liquid;
    //public GameObject buttonToDeactivate;

    public GameObject purrfectText; 

    public int maxLiquid = 10;
    public int currentLiquid;
    public LiquidBar liquidBar;
    private bool isPouring;

    //private int time;
    //private int timer;
    private float nextActionTime = 0.0f;
    // every 1f = 1 second
    private float period = 1f;

    public bool won;
    public int winningCondition;


    void Start()
    {
        currentLiquid = 0;
        liquidBar.SetMaxLiquid(maxLiquid);
        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        addEventSystem();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (isPouring)                          //if player is pouring..
        {
            if (Time.time > nextActionTime)     //each second..
            {
                nextActionTime = Time.time + period;
                AudioManager.PlaySound("PouringWater");
                FillCup(1);                     //fill cup with 1
            }
        }
        

        if (currentLiquid == winningCondition)          //if exactly at winning condition
        {
            //liquidBar.fillColor.GetComponent<Image>().color = new Color(1, 0.5370559f, 0); 
            purrfectText.SetActive(true);
        }
        else if(currentLiquid>winningCondition || currentLiquid < winningCondition)     //if lower or higher than winning condition
        {
           // liquidBar.fillColor.GetComponent<Image>().color = new Color(1, 0, 0);   //red;;
            purrfectText.SetActive(false);
        }

    }

    void FillCup(int amount)        //method to increase cup liquid amount
    {
        currentLiquid += amount;
        liquidBar.SetLiquid(currentLiquid);
    }



    //mouse-finger down (first touch)       - start filling method
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down!");
        FillingCanPourLiquid();
    }
    public void FillingCanPourLiquid()       //method to call when Can object is being pressed   
    {
        anim.Play("FillingCan_OnDown_Pour");
        StartCoroutine(Liquid());               //activate liquid sprite after 1 sec & set isPouring true
    }
    IEnumerator Liquid()
    {
        yield return new WaitForSeconds(1);
        liquid.SetActive(true);
        isPouring = true;
    }


    //mouse-finger up (second Touch)    - when stopped filling (stopped pressing)
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse Up!");
        AudioManager.audioSrc.Stop();
        liquid.SetActive(false);            //deactivate liquid sprite
        isPouring = false;                  //set ispouring bool false
        anim.Play("FillingCan_OnUp_Stop");  //play the stopping animation
        //EvaluateWin();
        canvas.Done();
    }


    public void EvaluateWin()
    {
        AudioManager.audioSrc.Stop();
        anim.speed = 0;
        if (currentLiquid==winningCondition )
        {
           // Debug.Log("current liquid is exactly winning condition, you win!");
            won = true;
            AudioManager.PlaySound("SuccessSFX");
        }
        else if(currentLiquid!= winningCondition)
        {
            AudioManager.PlaySound("BrewingFail_Sound");
            //Debug.Log("you lost!");
            won = false;
        }
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
