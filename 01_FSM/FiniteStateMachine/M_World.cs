using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// SCRIPT TO HANDLE WORLD STATE MACHINE
/// </summary>
public class M_World : MonoBehaviour
{
    private GameObject go;
    private M_StateMachine stateMachine;


    [HideInInspector] public GameObject dayLight;
    [HideInInspector] public GameObject nightLight;
    [HideInInspector] public GameObject nightMusic;
    [HideInInspector] public GameObject dayMusic;

    public bool isNight;
    public bool isBrewing;

    public static M_World Instance;

    // Start is called before the first frame update
    void Awake()
    {
        go = new GameObject();
        go.AddComponent<M_StateMachine>();
        stateMachine = go.GetComponent<M_StateMachine>();


        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);

        isNight = false;
        isBrewing = false;

        nightLight = GameObject.FindGameObjectWithTag("NightLight");
        nightMusic = SoundManager.Instance.nightMusic;
        dayLight = GameObject.FindGameObjectWithTag("DayLight");
        dayMusic = SoundManager.Instance.dayMusic;
        nightLight.SetActive(false); 
        nightMusic.SetActive(false);

        SoundManager.Instance.menuMusic.SetActive(false);

        stateMachine.ChangeState(new M_Day() );
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.ExecuteStateUpdate();
        if (!isNight)
        {
            SoundManager.Instance.nightMusic.SetActive(false);
        }
    }


    public void SeeForChange()              //call from where ever to look for state change and do it (call on sleep button press)
    {
        if (isNight)
        {
            stateMachine.ChangeState(new M_Night());
        }
        else if(!isNight)
        {
            stateMachine.ChangeState(new M_Day());
        }
    }

    public void ChangeStateToBrewing()
    {
        stateMachine.ChangeState(new M_Brewing());
    }
    public void ChangeStateToNight()
    {
        stateMachine.ChangeState(new M_Night());
    }
    public void ChangeStateToDay()
    {
        stateMachine.ChangeState(new M_Day());
    }
}
