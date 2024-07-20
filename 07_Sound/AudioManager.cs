using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip lillypadWaterSplash, buttonPress_SFX_01, buttonPress_SFX_02, buttonPress_SFX_03, openCloseJournal_SFX;           // UI SFX
    //public static AudioClip lillypadWaterSplash, buttonPress_SFX_02, buttonPress_SFX_03, openCloseJournal_SFX;           // UI SFX
    public static AudioClip pressBrewingStationButton, catSnoring, brewingSuccess_Sound, brewingFail_Sound, frogCroak, bushSound, sleepingInteractionSound;                         // BrewingGame SFX
    public static AudioClip pouringWaterSFX, cuttingSFX;                      // BrewingGame SFX

    //animal farm sounds
    public static AudioClip bee_SFX, magicFrog_SFX, cow_SFX, chicken_SFX;

    //OVERCAT sounds
    public static AudioClip cat_SFX_1, cat_SFX_2, cat_SFX_3;



    public static AudioSource audioSrc;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);

        //overcat sounds
        cat_SFX_1 = Resources.Load<AudioClip>("Cat_SFX_1");
        cat_SFX_2 = Resources.Load<AudioClip>("Cat_SFX_2");
        cat_SFX_3 = Resources.Load<AudioClip>("Cat_SFX_3");


        //World stuff
        sleepingInteractionSound = Resources.Load<AudioClip>("DoorClose");

        //Flower maze
        bushSound = Resources.Load<AudioClip>("BushSound");

        catSnoring = Resources.Load<AudioClip>("catSnoring");

        //LillypadPuzzle
        frogCroak = Resources.Load<AudioClip>("FrogCroak");
        lillypadWaterSplash = Resources.Load<AudioClip>("LillypadWaterSplash");

        //animal farm riddle
        bee_SFX = Resources.Load<AudioClip>("Bee_SFX");
        magicFrog_SFX = Resources.Load<AudioClip>("FrogMagic_SFX");
        cow_SFX = Resources.Load<AudioClip>("Cow_SFX");
        chicken_SFX = Resources.Load<AudioClip>("Chicken_SFX");

        //Buttons
        buttonPress_SFX_01 = Resources.Load<AudioClip>("SpriteButtonClickSound");                                           //Assigning values to actual AudioClip files in Resources folder
        //buttonPress_SFX_01 = Resources.Load<AudioClip>("ButtonPress_SFX_02");
        //buttonPress_SFX_01 = Resources.Load<AudioClip>("ButtonPress_SFX_03");
        //openCloseJournal_SFX = Resources.Load<AudioClip>("OpenCloseJournal_SFX");


        //Brewing game sounds
         brewingSuccess_Sound = Resources.Load<AudioClip>("SuccessSFX");
        brewingFail_Sound = Resources.Load<AudioClip>("BrewingFail_Sound");

        pouringWaterSFX = Resources.Load<AudioClip>("PouringWater");
        cuttingSFX = Resources.Load<AudioClip>("CuttingSound");



        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)                       ///AudioManager.PlaySound("SpriteButtonClickSound");     //use this to call sounds on other scripts
    {
        switch (clip)       //cases of audios to play
        {
            case "SpriteButtonClickSound":
                audioSrc.PlayOneShot(buttonPress_SFX_01);
                break;
            case "catSnoring":
                audioSrc.PlayOneShot(catSnoring);
                break;
            case "FrogCroak":                           ///AudioLevel.PlaySound("VS_Screen"); 
                audioSrc.PlayOneShot(frogCroak);
                break;
            case "BushSound":                           ///AudioLevel.PlaySound("VS_Screen"); 
                audioSrc.PlayOneShot(bushSound);
                break; 
            case "DoorClose":                           ///AudioLevel.PlaySound("VS_Screen"); 
                audioSrc.PlayOneShot(sleepingInteractionSound);
                break;
            //case "ButtonPress_SFX_03":                           ///AudioLevel.PlaySound("VS_Screen"); 
            //    audioSrc.PlayOneShot(buttonPress_SFX_03);
            //    break;
            //case "OpenCloseJournal_SFX":                           ///AudioLevel.PlaySound("VS_Screen"); 
            //    audioSrc.PlayOneShot(openCloseJournal_SFX);
            //    break;
            //case "PressBrewingStationButton":                           ///AudioLevel.PlaySound("VS_Screen"); 
            //    audioSrc.PlayOneShot(pressBrewingStationButton);
            //    break;
            case "SuccessSFX":                           ///AudioLevel.PlaySound("SuccessSFX"); 
                audioSrc.PlayOneShot(brewingSuccess_Sound);
                break;
            case "CuttingSound":                           ///AudioLevel.PlaySound("SuccessSFX"); 
                audioSrc.PlayOneShot(cuttingSFX);
                break; 
            case "PouringWater":                           ///AudioLevel.PlaySound("SuccessSFX"); 
                audioSrc.PlayOneShot(pouringWaterSFX);
                break;
            case "BrewingFail_Sound":                           ///AudioLevel.PlaySound("VS_Screen"); 
                audioSrc.PlayOneShot(brewingFail_Sound);
                break;
            case "LillypadWaterSplash":
                audioSrc.PlayOneShot(lillypadWaterSplash);
                break;



            case "Bee_SFX":
                audioSrc.PlayOneShot(bee_SFX);
                break;
            case "MagicFrog_SFX":
                audioSrc.PlayOneShot(magicFrog_SFX);
                break;
            case "Cow_SFX":
                audioSrc.PlayOneShot(cow_SFX);
                break;
            case "Chicken_SFX":
                audioSrc.PlayOneShot(chicken_SFX);
                break;

            case "Cat_SFX_1":
                audioSrc.PlayOneShot(cat_SFX_1);
                break;
            case "Cat_SFX_2":
                audioSrc.PlayOneShot(cat_SFX_2);
                break;
            case "Cat_SFX_3":
                audioSrc.PlayOneShot(cat_SFX_3);
                break;

        }
    }



}
