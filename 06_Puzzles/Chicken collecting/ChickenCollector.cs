using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollector : MonoBehaviour
{
    //public GameObject player;
    [HideInInspector] public Collider2D chickColl;

    public float speed;
    private Transform target;
    public float stoppingDistance;

    private bool hasCollected;

    public CharmPotion charmActive;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //charmActive = GameObject.FindGameObjectWithTag("CharmPotion").GetComponent<CharmPotion>();
    }


    void Update()
    {
        //check if collected
        if (hasCollected == true)
        {
            //follow player
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        } 
    }

    //on touch
    //public void OnMouseDown()
    //{
    //    //check if distance from obj to player is close enough
    //    if( (target.position- this.transform.position).magnitude <5f)
    //    {
    //        Debug.Log("I tapped a chick");
    //        hasCollected = true;
    //    }
        
    //}



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("deliverySpot"))
        {
            Debug.Log("Chicken Delivered");
            this.gameObject.SetActive(false);
        }

        if (other.CompareTag("Player") /*&& charmActive.isActive*/ )
        {
            Debug.Log("Chicken got charmed");
            hasCollected = true;
            
        }
    }
}
