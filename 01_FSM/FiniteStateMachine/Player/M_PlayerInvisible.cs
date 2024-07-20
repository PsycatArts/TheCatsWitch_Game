using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_PlayerInvisible : IState
{
    private SpriteRenderer player;
    private GameObject controller;
    private GameObject journal;
    private GameObject potionInventory;
    private GameObject lightObjects;
    private bool playerVisible;

    public M_PlayerInvisible(SpriteRenderer player, GameObject controller, bool playerVisible, GameObject lightObjects, GameObject journal, GameObject potionInventory)       //constructor to always contain light obj
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
        Debug.Log("Entered player invisible state");
        playerVisible = false;
        lightObjects.SetActive(false);
        player.enabled = false;
        controller.SetActive(false);
        potionInventory.SetActive(false);
        journal.SetActive(false);
        //controller.GetComponentInChildren<Image>().enabled = false;
        //player.SetActive(false);
    }

    public void Execute()
    {
        //Debug.Log("Executing/updating player invisible state");
    }

    public void Exit()
    {
        Debug.Log("Exited player invisible state");
    }


}
