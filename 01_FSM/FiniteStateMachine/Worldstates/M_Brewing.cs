using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Brewing : IState
{
    public M_Brewing()
    {
    }
    public void Enter()
    {
        Debug.Log("Entering Brewing State");

       // M_World.Instance.nightLight.SetActive(true);
       // SoundManager.Instance.nightMusic.SetActive(true);
       SoundManager.Instance.brewingMusic.SetActive(true);

    }

    public void Execute()
    {
        Debug.Log("executing Brewing State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Brewing State");

        //M_World.Instance.nightLight.SetActive(false);
        SoundManager.Instance.brewingMusic.SetActive(false);
    }
}
