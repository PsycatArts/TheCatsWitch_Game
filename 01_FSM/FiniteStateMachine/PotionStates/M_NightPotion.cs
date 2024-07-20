using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_NightPotion : IState
{

    private bool hasNightPotion;
    

    public M_NightPotion(bool hasNightPotioncollected)
    {
        this.hasNightPotion = hasNightPotioncollected;
        
    }


    public void Enter()
    {
        hasNightPotion = true;
        
        Debug.Log("Entering/Equipping Night Potion");
    }

    public void Execute()
    {
        Debug.Log("Currently running Night Potion");
    }

    public void Exit()
    {
        hasNightPotion = false;
        
        Debug.Log("Exiting/Unequipping Night Potion");
    }

}
