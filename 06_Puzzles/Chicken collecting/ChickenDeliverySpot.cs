using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDeliverySpot : MonoBehaviour
{
    private ChickenCollector chicken;

    public void Start()
    {
        chicken = GameObject.FindGameObjectWithTag("Chicken").GetComponent<ChickenCollector>();
    }

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other == chicken.chickColl )
    //    {
    //        chicken.gameObject.SetActive(false);
    //    }
    //}
}
