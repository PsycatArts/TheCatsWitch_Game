using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Knife : MonoBehaviour
{
    public GameObject knife;

    //these two vectors combined, give one cutting spot
    private Vector2 possiblePosOne;     //-3.08
    private Vector2 possiblePosTwo;     //-1.64


    public GameObject cuttingText;

    public Animator anim;

    public bool won;
    [HideInInspector] public int cutCount;               //counter how many cuts the player managed to achieve
    public int winningCondition;                         //how many cuts player needs to achieve to win

    [HideInInspector] public int failedCutCount;        //counts failed taps to maybe make this losing condition
    public int failingCondition;


    public static Knife Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cutCount = 0;                       //make sure cut count is 0 at start
        failedCutCount = 0;
        cuttingText.SetActive(false);
        possiblePosOne.x = -1.23f;
        possiblePosTwo.x = 0.4f;
    }
    // Update is called once per frame
    void Update()
    {
        if (cutCount == winningCondition && failedCutCount < failingCondition)      //if player manages to hit enough right cuts
        {
            Debug.Log("DEBUG TEST: WON = true");
             won = true;
        }
        else if(cutCount == winningCondition && failedCutCount >= failingCondition)
        {
            Debug.Log("DEBUG TEST: WON = false");
            won = false;
        }
    }
    public void DoCut()
    {
        if (knife.transform.position.x >= possiblePosOne.x && knife.transform.position.x <= possiblePosTwo.x)
        {
            AudioManager.PlaySound("CuttingSound");
            cutCount++;
            Debug.Log("Cut Count: " + cutCount);
            cuttingText.SetActive(true);
            Debug.Log("Knife is in that sweet spot");
            anim.speed += 0.5f;
            StartCoroutine(CuttingTextDissappear(1));
        }
        else
        {
            failedCutCount++;
            Debug.Log("Wrong Timing Tap, you missclicked " + failedCutCount + " times..");
        }
    }
    //trash method that can be deleted later when there's no placeholder CUT text needed
    private IEnumerator CuttingTextDissappear(float waitTime)
    {
       // Debug.Log("Coroutine");
            yield return new WaitForSeconds(waitTime);
            cuttingText.SetActive(false);
    }
}
