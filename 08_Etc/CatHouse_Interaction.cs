using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// script to activate/deactivate sleep button & call -> change world state to day/night
/// </summary>
public class CatHouse_Interaction : MonoBehaviour
{
    public GameObject sleepSpriteButton;
    public Sprite sunSprite;
    public Sprite moonSprite;

    //private bool hasNightCollected;
    


    // Start is called before the first frame update
    void Start()
    {
        sleepSpriteButton.SetActive(false);

    }
    private void Update()
    {
       if (M_World.Instance.isNight)        //if it IS NIGHT, set the sprite button to sun
        {
            sleepSpriteButton.GetComponent<SpriteRenderer>().sprite = sunSprite;
        }else if (!M_World.Instance.isNight)
        {
            sleepSpriteButton.GetComponent<SpriteRenderer>().sprite = moonSprite;
        }
    }

    //Button press to call change of states
    //public void SleepAndChangeState()
    //{
    //    Debug.Log("Pressing switch button");
    //    if (M_Potion.Instance.hasNightPotionActive==true)       //if Night potion is active....
    //    {
    //        //change world state
    //        if (!M_World.Instance.isNight)                 //if its day
    //        {
    //            M_World.Instance.isNight = true;          //set key bool isNight true - to activate night
    //        }
    //        else
    //        {
    //            M_World.Instance.isNight = false;        //set key bool isNight false - to activate day
    //        }
    //        M_World.Instance.SeeForChange();            //switch the state depending on key bool
    //    }
    //    else if (M_Potion.Instance.hasNightPotionActive==false)
    //    {
    //        Debug.Log("I can not sleep because i have no night potion active");
    //    }


    //    //change world state
    //    //if (!M_World.Instance.isNight)                 //if its day
    //    //{
    //    //    M_World.Instance.isNight = true;          //set key bool isNight true - to activate night
    //    //}
    //    //else
    //    //{
    //    //    M_World.Instance.isNight = false;        //set key bool isNight false - to activate day
    //    //}
    //    //M_World.Instance.SeeForChange();            //switch the state depending on key bool
    //}


    //if player close to cat house, activate UI Button to sleep
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*&& M_Potion.Instance.hasNightPotionActive*/)           //if player close to house 
        {
            sleepSpriteButton.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*&& M_Potion.Instance.hasNightPotionActive*/)           //if player close to house 
        {
            sleepSpriteButton.SetActive(true);
        }
    }


    //if player out of range from cat house, deactivate UI button
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sleepSpriteButton.SetActive(false);
            //sleepInteractButton.gameObject.SetActive(false);
        }
    }
}
