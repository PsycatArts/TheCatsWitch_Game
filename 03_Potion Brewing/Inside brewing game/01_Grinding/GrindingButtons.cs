using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SCRIPT FOR INSIDE OF GRINDING SCENE - failure & Success buttons
/// LOADING SCENES
/// </summary>
public class GrindingButtons : MonoBehaviour
{
 
    //if grinding failed, call this button on press to try again
    public void TryAgainButton()
    {
        SceneManager.LoadScene("04_PotionBrewingStep_1");
    }

    //if grinding successfull, go back to mainhub & add the first potion to inventory (also activate inventory
    public void DoneButton()
    {
        SceneManager.LoadScene("TESTMainWorld");             // !!  REPLACE THIS WITH ACTUAL SCENE LATER:  02_MainWorld
    }
}
