using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemWorldObject", menuName = "ScriptableObjects/ItemWorldObject")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemType;
    public bool isCollected;
    public Sprite itemSprite;
}
