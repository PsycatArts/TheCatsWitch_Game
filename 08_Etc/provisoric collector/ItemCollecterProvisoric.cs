using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecterProvisoric : MonoBehaviour
{
    //public CollectManagerProvisoric collectManager;
    public GameObject pickupSpriteButton;
    // Start is called before the first frame update
    void Start()
    {
        pickupSpriteButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player") )
        {
            pickupSpriteButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            pickupSpriteButton.SetActive(false);
        }
    }

    //public void PickupHerb()
    //{
    //    AudioManager.PlaySound("SpriteButtonClickSound");
    //    CollectManagerProvisoric.Instance.hasCollectedHerbs = true;
    //    // this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //    Destroy(this.gameObject);
    //}

}
