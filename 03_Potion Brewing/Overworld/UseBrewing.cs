using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;


/// <summary>
/// SCRIPT TO ACTIVATE BREWING BUTTON IF PLAYER CLOSE TO CAULDRON
/// </summary>
public class UseBrewing : MonoBehaviour
{

    //public Button brewingButton;
    public GameObject brewingSpriteButton;
    //public CollectManagerProvisoric collectManager;
   // private GameObject panel;
   // public Text matchText;


    public ItemScriptableObject catnip;
    public ItemScriptableObject raddish;
    public ItemScriptableObject spinach;
    
    // Start is called before the first frame update
    void Start()
    {
        // brewingButton.GetComponent<Button>();
        brewingSpriteButton.gameObject.SetActive(false);
    }

    //method to call when clicking on Brewing button
    public void GoToBrewingGame()                           
    {
        SceneManager.LoadScene("04_PotionBrewingStep_1");
        
    }

    //provisoric method to call when clicking brewing button (FOR PLAYABLE PROTOTYPE)
    public void StartBrewing()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");

        //if there is no charm potion yet..
        if (!CollectManagerProvisoric.Instance.hasCharmPotion)    
        {
            if (!catnip.isCollected)        //if no catnip..
            {
                PauseMenu.Instance.cauldronPanel.SetActive(true);
                PauseMenu.Instance.cauldronPanelMissingIngredient.SetActive(true);
                //PauseMenu.Instance.cauldronPanelCantBrew.GetComponentInChildren<Text>().text = "You don't have the ingredients to brew a magical potion ";
                //matchText.text = "You don't have the ingredients to brew a magical potion ";
            }
            else if (catnip.isCollected/* && CollectManagerProvisoric.Instance.hasCharmPotion ==false*/)
            {
                PauseMenu.Instance.cauldronPanel.SetActive(true);
                PauseMenu.Instance.cauldronPanelBrewingStep1.SetActive(true);
                // SceneManager.LoadScene("04_PotionBrewingStep_1");
            }
        }



        //if we have charmPotion but DONT have nightPotion.. 
        if (CollectManagerProvisoric.Instance.hasCharmPotion && !CollectManagerProvisoric.Instance.hasNightPotion)      
        {
            if (!catnip.isCollected && !raddish.isCollected || catnip.isCollected && !raddish.isCollected)        //if catnip & raddish both not collected yet..
            {
                PauseMenu.Instance.cauldronPanel.SetActive(true);
                PauseMenu.Instance.cauldronPanelMissingIngredient.SetActive(true);
            }
            if (catnip.isCollected && raddish.isCollected )         //if catnip and raddish are both collected..
            {
                PauseMenu.Instance.cauldronPanel.SetActive(true);
                PauseMenu.Instance.cauldronPanelBrewingStep2.SetActive(true);
                //SceneManager.LoadScene("04_PotionBrewingStep_1");   //load potion brewing step 1 which will then lead to two

            }
        }


        //if we have charmPotion but DONT have nightPotion.. 
        if (CollectManagerProvisoric.Instance.hasCharmPotion && CollectManagerProvisoric.Instance.hasNightPotion)
        {
            PauseMenu.Instance.cauldronPanel.SetActive(true);
            PauseMenu.Instance.cauldronPanelMissingIngredient.SetActive(true);
            //PauseMenu.Instance.cauldronPanel.SetActive(true);
            //PauseMenu.Instance.cauldronPanel.GetComponentInChildren<Text>().text = "You don't have the ingredients to brew a magical potion ";
        }



        // SceneManager.LoadScene("04_PotionBrewingStep_1");
    }

   

    //if player close to cauldron, activate brewing button
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            brewingSpriteButton.gameObject.SetActive(true);
            //brewingButton.(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            brewingSpriteButton.gameObject.SetActive(false);
            //brewingButton.(true);
        }
    }
}
