using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerM : MonoBehaviour
{

    //OVERCAT DIALOGUE
    public bool tutorialConvo_1;        //to check if first introduction dialogue of cat has been player already
    public bool mockingConvo_2;        //to play after 1 was played
    public bool giveStrengthRecip_3;        
    public bool giveNightRecip_3;        
    public bool goToBed_4;        


    //NARRATOR HINTS
    public bool flowerMazeWarning_1;        //to play once in front of flower maze
    public bool magicMazeWarning_2;        //to play once in front of flower maze
    public bool magicMazeEnter_3;        //to play once in front of flower maze
    public bool nightForFirstTime_4;        //to play once in front of flower maze
    public bool lillypadFail_5;        //to play once in front of flower maze


    //FARMER NPC
    public bool riddleStart_1;
    public bool questBee_wrongAnimal_2;



    public static DialogueManagerM Instance;


    void Start()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);


        tutorialConvo_1 = false;
        mockingConvo_2 = false;
        giveStrengthRecip_3 = false;
        giveNightRecip_3 = false;
        goToBed_4 = false;


        flowerMazeWarning_1 = false;
        magicMazeWarning_2 = false;
        magicMazeEnter_3 = false;
        nightForFirstTime_4 = false;
        lillypadFail_5 = false;


        riddleStart_1 = false;
        questBee_wrongAnimal_2 = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (tutorialConvo_1 == true)
        {
            //CHECK IF NOT BUGGY IN EXPORTED GAME
            JournalBase.Instance.journalButton.SetActive(true);
            QuestPage_1.Instance.ShowTheHint(QuestPage_1.Instance.p1);
            
        }
    }
}
