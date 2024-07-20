using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalBase : MonoBehaviour
{
    public static bool journalOpen = false;

    public GameObject journalPanel;
    public GameObject journalButton;


    public GameObject questPage1;
    public GameObject charmPage2;
    public GameObject NightPage3;
    public GameObject StrengthPage4;

    public GameObject newQuestMarker;

    public static JournalBase Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        journalButton.SetActive(false);
        newQuestMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenJournal()
    {
        journalPanel.SetActive(true);

        if (newQuestMarker.activeInHierarchy)
        {
            newQuestMarker.SetActive(false);
        }
    }

    public void CloseJournal()
    {
        journalPanel.SetActive(false);


    }

    //call on button press charm tab
    public void OpenCharmPage()
    {
        if (DialogueManagerM.Instance.tutorialConvo_1 == true)      //if first convo happened, we got charm recipie and we can open
        {
            //close all other pages
            questPage1.SetActive(false);
            NightPage3.SetActive(false);
            StrengthPage4.SetActive(false);

            //open charm page 
            charmPage2.SetActive(true);
        }
    }

    public void OpenNightPage()
    {
        if (DialogueManagerM.Instance.giveNightRecip_3 == true)      //if first convo happened, we got charm recipie and we can open
        {
            //close all other pages
            questPage1.SetActive(false);
            charmPage2.SetActive(false);
            StrengthPage4.SetActive(false);

            //open charm page 
            NightPage3.SetActive(true);
        }
    }

    public void OpenStrengthPage()
    {
        if (DialogueManagerM.Instance.giveStrengthRecip_3 == true)      //if first convo happened, we got charm recipie and we can open
        {
            //close all other pages
            questPage1.SetActive(false);
            NightPage3.SetActive(false);
            charmPage2.SetActive(false);

            //open charm page 
            StrengthPage4.SetActive(true);
        }
    }

    public void OpenQuestPage()
    {

            //close all other pages
            StrengthPage4.SetActive(false);
            NightPage3.SetActive(false);
            charmPage2.SetActive(false);

            //open charm page 
            questPage1.SetActive(true);
       
    }
}
