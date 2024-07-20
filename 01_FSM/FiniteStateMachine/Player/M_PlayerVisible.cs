using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerVisible : IState
{
    private SpriteRenderer player;
    private GameObject controller;
    private GameObject lightObjects;
    private GameObject journal;
    private GameObject potionInventory;
    private bool playerVisible;

    public M_PlayerVisible(SpriteRenderer player, GameObject controller, bool playerVisible, GameObject lightObjects, GameObject journal, GameObject potionInventory)       //constructor to always contain light obj
    {
        this.player = player;
        this.controller = controller;
        this.playerVisible = playerVisible;
        this.lightObjects = lightObjects;
        this.journal = journal;
        this.potionInventory = potionInventory;


    }
    public void Enter()
    {
        playerVisible = true;
        Debug.Log("Entered player visible state");
        lightObjects.SetActive(true);
        player.enabled = true;
        controller.SetActive(true);
        journal.SetActive(true);
        potionInventory.SetActive(true);
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }


}
