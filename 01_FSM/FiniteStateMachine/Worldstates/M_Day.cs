using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Day : IState
{
    public M_Day()  
    {
    }


    public void Enter()
    {
        Debug.Log("Entering Day State");

        SoundManager.Instance.dayMusic.SetActive(true);
        M_World.Instance.dayLight.SetActive(true);
    }

    public void Execute()
    {
        Debug.Log("executing Day State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Day State");
        SoundManager.Instance.dayMusic.SetActive(false);
        M_World.Instance.dayLight.SetActive(false);
    }

  
}
