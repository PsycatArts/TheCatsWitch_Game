using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UI_Bar_Step3 : MonoBehaviour
{
    //public GameObject fillingUIBar;

   // public int startTime;            //time it will wait before starting actual game
    //public float startTimer = 0f;    //timer to keep track of time 

   // public int time;                //time it needs to fill up 
    //public float timer = 0f;        //timer to keep track of time

    //private bool m_start = false;
   // private bool didStartAlr = false;

    private bool messageShown;

   // public Image panelImage;
    //public Text matchText;
    
   
   // public GameObject winButton;
   // public GameObject failButton;

    public FillingCan fillingCan;

    public GameObject panelEnd;
    public GameObject guideButton;
    public GameObject winButton;
    public GameObject failButton;

    //public Text matchText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Done()
    {
        panelEnd.SetActive(true);                 //activate the win/lose panel 
        Debug.Log("Time is over");
        fillingCan.anim.speed = 0;
        fillingCan.EvaluateWin();
        if (fillingCan.won)
        {
            AudioManager.PlaySound("SuccessSFX");
            panelEnd.SetActive(true);
            guideButton.SetActive(false);
            winButton.SetActive(true);
            //winButton.SetActive(true);              //activate the winning button
            //matchText.text = "You Won and managed to pour exactly "  + fillingCan.winningCondition.ToString() + " drops! ";

        }else if (!fillingCan.won)
        {
            AudioManager.PlaySound("BrewingFail_Sound");
            panelEnd.SetActive(true);
            guideButton.SetActive(false);
            Debug.Log("Player Lost");                                                                     //if no matching drawing found (player didnt grind properly)
            failButton.SetActive(true);
            //failButton.SetActive(true);
            //matchText.text = "You Lost because you poured " + fillingCan.currentLiquid.ToString() + " drops! ";
        }
       
    }

}
