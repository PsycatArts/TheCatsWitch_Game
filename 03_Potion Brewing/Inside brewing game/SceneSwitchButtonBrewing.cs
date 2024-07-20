using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// SCRIPT FOR INSIDE OF POTION BREWING STEPS - failure & Success buttons
/// LOADING SCENES per string
/// </summary>
public class SceneSwitchButtonBrewing : MonoBehaviour
{
    public string sceneTryAgain;
    public string sceneMainWorld;
    //private GameObject collect;

    

    private void Start()
    {

        //collect = GameObject.FindGameObjectWithTag("CollectManager");
        //collect = CollectManagerProvisoric.Instance.gameObject;
        M_World.Instance.ChangeStateToBrewing();
        M_Player.Instance.PlayerInvisible();

    }
    //if grinding failed, call this button on press to try again
    public void TryAgainButton()
    {
        SceneManager.LoadScene(sceneTryAgain);
    }

  //method to call provisoricly to simple go back to main world
    public void DoneButton()
    {
        
        M_Player.Instance.PlayerVisible();
        M_World.Instance.SeeForChange();
       // M_World.Instance.ChangeStateToDay();
        SceneManager.LoadScene(sceneMainWorld);
    }

    public void DoneWithBrewingMinigame()
    {
        SceneManager.LoadScene(sceneMainWorld);
    }

    //if grinding successfull, go back to mainhub & add the first potion to inventory (also activate inventory
    public void SucceedBrewingStepONE()
    {
        if (!CollectManagerProvisoric.Instance.hasCharmPotion)      //if we dont have charm potion yet..
        {
            SceneManager.LoadScene(sceneMainWorld);                     //go back to main world
            CollectManagerProvisoric.Instance.hasCharmPotion = true;
            PotionInv.Instance.activeSlot.GetComponentInChildren<Image>().sprite = PotionInv.Instance.charm;
            M_Player.Instance.PlayerVisible();
            M_World.Instance.SeeForChange();
        }else if (CollectManagerProvisoric.Instance.hasCharmPotion)     //if we have charm potion already, means we're doing night potion so we need step 2
        {
            SceneManager.LoadScene("05_PotionBrewingStep_2");
        }
        
    }
    public void SucceedBrewingStepTWO()
    {
        if (!CollectManagerProvisoric.Instance.hasNightPotion)      //if we dont have charm potion yet..
        {
            SceneManager.LoadScene(sceneMainWorld);                     //go back to main world
            CollectManagerProvisoric.Instance.hasNightPotion = true;
            PotionInv.Instance.activeSlot.GetComponentInChildren<Image>().sprite = PotionInv.Instance.night;
            M_Player.Instance.PlayerVisible();
            M_World.Instance.SeeForChange();
        }
        //else if (CollectManagerProvisoric.Instance.hasCharmPotion)     //if we have charm potion already, means we're doing night potion so we need step 2
        //{
        //    SceneManager.LoadScene("05_PotionBrewingStep_2");
        //}

    }
    public void SucceedBrewingThreeMinigame()
    {
        SceneManager.LoadScene("00_MainMenu");
    }
}
