using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// script to animate the filling bar after a certain waiting time (MANAGE TIME)
/// </summary>

public class UI_Bar : MonoBehaviour
{
    //public GameObject fillingUIBar;

    //public int startTime;            //time it will wait before starting actual game
   // public float startTimer = 0f;    //timer to keep track of time 

   // public int time;                //time it needs to fill up 
   // public float timer = 0f;        //timer to keep track of time

    //private bool m_start = false;
    //private bool didStartAlr = false;

    private bool messageShown;

    
    //private bool win;

    public Knife knife;

    public GameObject panelEnd;
    public GameObject guideButton;
    public GameObject winButton;
    public GameObject failButton;

    //public Text matchText;

    public GameObject cuttingButton;

    // Start is called before the first frame update
    void Start()
    {
        cuttingButton.SetActive(true);
        messageShown = false;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (knife.cutCount == knife.winningCondition && !messageShown)      //!messageShown so it only calls once
        {
            messageShown = true;
            Done();
        }
    }

    public void Done()
    {
        StartCoroutine(WaitASec(1));
        cuttingButton.SetActive(false);
        //panelEnd.SetActive(true);
        //guideButton.SetActive(false);

        Debug.Log("Game is done");
        knife.anim.speed = 0;
        

        if (/*knife.won==true*/Knife.Instance.cutCount == Knife.Instance.winningCondition && Knife.Instance.failedCutCount < Knife.Instance.failingCondition)                          //if player won
        {
            Debug.Log("Player Won");
            panelEnd.SetActive(true);
            guideButton.SetActive(false);
            winButton.SetActive(true);              //activate the winning button
            AudioManager.PlaySound("SuccessSFX");

        }
        else if (!Knife.Instance.won && Knife.Instance.failedCutCount >= Knife.Instance.failingCondition/*!knife.won && knife.failedCutCount >= knife.failingCondition*/)      //if player lost because too many failed cuts..
        {
            panelEnd.SetActive(true);
            guideButton.SetActive(false);
            Debug.Log("Player Lost");                                                                     //if no matching drawing found (player didnt grind properly)
            failButton.SetActive(true);                                             //activate fail button to try again
            AudioManager.PlaySound("BrewingFail_Sound");
            // matchText.text = "You Lost because you missed " + knife.failedCutCount.ToString() + " cuts! ";
            
        }
        //else if (!knife.won && knife.failedCutCount <= knife.failingCondition)      //if player lost because not enough cuts made..
        //{                                                                           //if no matching drawing found (player didnt grind properly)
         //   AudioManager.PlaySound("BrewingFail_Sound");
          //  failButton.SetActive(true);                                             //activate fail button to try again
          // // matchText.text = "You Lost because you didnt do enough cuts " ;         
         //   //Debug.Log("Player Lost");
       // }
    }

    //public void AnimateBar()
    //{
    //    LeanTween.scaleX(fillingUIBar, 1, time);
    //}


    private IEnumerator WaitASec(float waitTime)
    {
        // Debug.Log("Coroutine");
        yield return new WaitForSeconds(waitTime);
    }
}
