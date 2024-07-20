using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FarmAnimalObject", menuName = "ScriptableObjects/FarmAnimalObject")]
public class AnimalScriptableObject : ScriptableObject
{
    public string animalType;
    public bool isRight;
    public bool isCollected;
   

}
