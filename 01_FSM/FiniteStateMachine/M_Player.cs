using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SCRIPT TO HANDLE PLAYER STATE MACHINE
/// </summary>

public class M_Player : MonoBehaviour
{

   // private M_StateMachine stateMachine;//= new M_StateMachine();
    private GameObject go;
    private M_StateMachine stateMachine;


    public static M_Player Instance;                    //having only one instance in the scene

    private SpriteRenderer player;
    private GameObject controller;
    private GameObject journal;
    private GameObject potionInventory;
    private GameObject lightObjects;
    //private LightPersistency light;
    public bool playerVisible;

   
    // Start is called before the first frame update
    void Awake()
    {
        go = new GameObject();
        go.AddComponent<M_StateMachine>();
        stateMachine = go.GetComponent<M_StateMachine>();

        //stateMachine.GetComponent<M_StateMachine>();

        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);

        //player = GameObject.FindGameObjectWithTag("Player");
        player = PlayerInfo.instance.playersprite;
        controller = GameObject.FindGameObjectWithTag("JoyStick");
        lightObjects = GameObject.FindGameObjectWithTag("LightManager");
        potionInventory = GameObject.FindGameObjectWithTag("PotionInventory");
        journal = GameObject.FindGameObjectWithTag("Journal");

        //stateMachine.ChangeState(new M_PlayerVisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
        PlayerVisible();
        //stateMachine.
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.ExecuteStateUpdate();

        
        //if (SceneManager.GetActiveScene().name == "02_MainWorld")
        //{
        //    playerVisible = true;
        //    stateMachine.ChangeState(new M_PlayerVisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
        //    //Debug.Log("CURRENT SCENE IS MAIN WORLD");
        //}

        //if (SceneManager.GetActiveScene().name == "04_PotionBrewingStep_1")
        //{
        //    playerVisible = false;
        //    stateMachine.ChangeState(new M_PlayerInvisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
        //    //Debug.Log("CURRENT SCENE IS BREWING STEP ONE");
        //}
        //if (SceneManager.GetActiveScene().name == "00_MainMenu")
        //{
        //    playerVisible = false;
        //    stateMachine.ChangeState(new M_PlayerInvisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
        //}
    }


    //call from where ever to set playerState to visible
    public void PlayerVisible()
    {
       // if (SceneManager.GetActiveScene().name == "02_MainWorld")
       // {
            playerVisible = true;
            stateMachine.ChangeState(new M_PlayerVisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
            //Debug.Log("CURRENT SCENE IS MAIN WORLD");
       // }
    }

    public void PlayerInvisible()
    {
        //if (SceneManager.GetActiveScene().name == "04_PotionBrewingStep_1")
        //{
            playerVisible = false;
            stateMachine.ChangeState(new M_PlayerInvisible(player, controller, playerVisible, lightObjects, journal, potionInventory));
            //Debug.Log("CURRENT SCENE IS BREWING STEP ONE");
        //}
    }
}
