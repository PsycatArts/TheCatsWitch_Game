using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Night : IState
{
    public M_Night()     
    {
    }
    public void Enter()
    {
        Debug.Log("Entering Night State");

        M_World.Instance.nightLight.SetActive(true);
        SoundManager.Instance.nightMusic.SetActive(true);

    }

    public void Execute()
    {
        Debug.Log("executing Night State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Night State");
        SoundManager.Instance.dayMusic.SetActive(false);
        M_World.Instance.nightLight.SetActive(false);
       // SoundManager.Instance.dayMusic.SetActive(false);
    }

}
