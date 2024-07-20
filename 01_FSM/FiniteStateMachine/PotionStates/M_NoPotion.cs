using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_NoPotion : IState

{
    public void Enter()
    {
        Debug.Log("No potionState entered");
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        Debug.Log("No potionState exited");
    }

   
}
