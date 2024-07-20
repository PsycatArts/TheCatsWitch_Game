using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_CharmPotion : IState
{
    private bool hasCharmPotionActive;
    //private GameObject charmScreenEffect;

    public M_CharmPotion(bool hasCharmPotionActive/*, GameObject charmScreenEffect*/)
    {
        this.hasCharmPotionActive = hasCharmPotionActive;
        //this.charmScreenEffect = charmScreenEffect;

    }

    public void Enter()
    {
        hasCharmPotionActive = true;
        //charmScreenEffect.SetActive(true);
        Debug.Log("Entering/Equipping Charm Potion");
    }

    public void Execute()
    {
        Debug.Log("Currently running Charm Potion");
    }

    public void Exit()
    {
        hasCharmPotionActive = false;
        //charmScreenEffect.SetActive(false);
        Debug.Log("Exiting/Unequipping Charm Potion");
    }

  
}
