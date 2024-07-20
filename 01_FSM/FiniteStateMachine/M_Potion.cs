using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script to handle the potionStates
/// </summary>
public class M_Potion : MonoBehaviour
{
    //private M_StateMachine potionStateMachine = new M_StateMachine();
    private GameObject go;
    private M_StateMachine potionStateMachine;

    public bool hasNightPotionActive;

    public bool hasCharmPotionActive;
   // public GameObject charmScreenEffect;


    public static M_Potion Instance;



    // Start is called before the first frame update
    void Start()
    {
        go = new GameObject();
        go.AddComponent<M_StateMachine>();
        potionStateMachine = go.GetComponent<M_StateMachine>();


        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);

        hasNightPotionActive = false;
        hasCharmPotionActive = false;
        potionStateMachine.ChangeState(new M_NoPotion() );
    }

    // Update is called once per frame
    void Update()
    {
        potionStateMachine.ExecuteStateUpdate();
    }

    public void NightPotionIsActive()              //call from where ever to look for state change and do it (call on sleep button press)
    {
        //if (hasNightPotionCollected)
        //{
            potionStateMachine.ChangeState(new M_NightPotion(hasNightPotionActive) );
        //}
        //else
        //{
        //    return;
        //}
    }

    public void CharmPotionIsActive()              //call from where ever to look for state change and do it (call on Charm button press)
    {
        //if (hasCharmPotionActive)
        //{
            potionStateMachine.ChangeState(new M_CharmPotion(hasCharmPotionActive/*, charmScreenEffect*/));
        //}
        //else
        //{
        //    return;
        //}
    }
}
