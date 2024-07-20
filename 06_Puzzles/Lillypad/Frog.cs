using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public GameObject spriteButton; //Charm button to activate when player close
    public Sprite stopCharmSprite;
    public Sprite doCharmSprite;

    private Transform target;       //player to follow
    public float speed;
    public float stoppingDistance;

    public bool followPlayer;


    public GameObject respawnPoint;

    //public GameObject charmScreenEffect;
    //public static Frog Instance;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DoFollow();

        if (!followPlayer)
        {
            spriteButton.GetComponent<SpriteRenderer>().sprite = doCharmSprite;
        }
        else if (followPlayer)
        {
            spriteButton.GetComponent<SpriteRenderer>().sprite = stopCharmSprite;       //change button into the STOP one
        }
    }

    public void NegateFollow()
    {
        AudioManager.PlaySound("FrogCroak");
        if (!followPlayer)
        {
            
            followPlayer = true;
        }
        else if (followPlayer) 
        {
            
            //AudioManager.PlaySound("frogCroak");
            followPlayer = false;
        }
    }
    private void DoFollow()
    {
        if (followPlayer)
        {
            //charmScreenEffect.SetActive(true);
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      //follow
            }
        }
        else
        {
            //charmScreenEffect.SetActive(false);
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && M_Potion.Instance.hasCharmPotionActive)           //if player close to house and night potion is collected..
        {
            spriteButton.SetActive(true);
            //sleepInteractButton.gameObject.SetActive(true);
        }


        if (other.CompareTag("Floor"))
        {
            Debug.Log("frog on floor");
            
            this.gameObject.transform.position = respawnPoint.transform.position;
            followPlayer = false;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            spriteButton.SetActive(false);
        }
    }
}
