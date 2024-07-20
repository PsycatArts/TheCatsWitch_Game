using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryRiddle : MonoBehaviour
{
    public Animal animalToDeliver_01;
    public Animal animalToDeliver_02;
   // private bool wonRiddle;

    public GameObject raddish;

    public static DeliveryRiddle Instance;


    void Start()
    {
        Instance = this;
       // wonRiddle = false;
        raddish.SetActive(false);
    }

    void Update()
    {
        //IF FIRST ANIMAL HAS BEEN DELIVERED....
        if (animalToDeliver_01.animalScriptableObject.isCollected)
        {
            //ADD CODE LINE: change NPC dialogue to be for second delivery animal now, because first has been found..
            animalToDeliver_02.animalScriptableObject.isRight = true;                                       //then make animal 2 the right one & deliverable
            //animalToDeliver_01.
        }
        //IF SECOND ANIMAL HAS BEEN DELIVERED....
        //if (animalToDeliver_02.animalScriptableObject.isCollected )
        //{
        //    Debug.Log("COLLECTOR + " + animalToDeliver_02.animalScriptableObject.animalType.ToString());
        //    //ADD CODE LINE: change NPC dialogue to say "ay nice you did it" or something..
        //    //grant new potion/ingredient
        //}
    }

    //if animal touches the delivery spot..
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FarmAnimal") )           //if player close to house and night potion is collected..
        {
            Debug.Log("An animal has been delivered");
            other.gameObject.GetComponent<Animal>().AnimalDelivered();
        }
    }

}
