using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script that creates an inventory, has to be attached to player & assign size in inspector
/// </summary>
public class M_Inventory : MonoBehaviour
{
    public string inventoryName;
    public bool[] IsFilled;         //array of bool expr. Telling if slot is taken or not

    public GameObject[] slots;      //reference to BOXprefab in which item will get placed

    public int allowedItemID;       //refference to ID



}

