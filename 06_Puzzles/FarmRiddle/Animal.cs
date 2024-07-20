using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Animal : MonoBehaviour
{
    public GameObject spriteButton; //Charm button to activate when player close
    public AnimalScriptableObject animalScriptableObject;
    public Sprite stopCharmSprite;
    public Sprite doCharmSprite;

    private Transform target;       //player to follow
    public float speed;
    public float stoppingDistance;
    public bool followPlayer;

    public GameObject respawnPoint;

    public GameObject glitterEffectRight;
    public GameObject glitterEffectWrong;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerInfo.instance.playertransform;
        animalScriptableObject.animalType.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DoFollow();
        //sprite button change
        if (!followPlayer)
        {
            spriteButton.GetComponent<SpriteRenderer>().sprite = doCharmSprite;
        }
        else if (followPlayer)
        {
            spriteButton.GetComponent<SpriteRenderer>().sprite = stopCharmSprite;       //change button into the STOP one
        }
    }

    //call when animal hits delivery spot   (frog 1 - bee 2)
    public void AnimalDelivered()
    {
        if (animalScriptableObject.isRight)     //if the right animal was delivered
        {

            Debug.Log("The Right animal is on the delivery spot - SUCCESS");
            StartCoroutine(StopFollow());
            animalScriptableObject.isCollected = true;
            GameObject go = Instantiate(glitterEffectRight, this.gameObject.transform.position, Quaternion.identity) as GameObject;        //instantiate glitter prefab
            go.transform.parent = this.gameObject.transform;        //set parent of glitter prefab: animal obj

            //if the first animal was delivered..but second not..
            if (DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected && !DeliveryRiddle.Instance.animalToDeliver_02.animalScriptableObject.isCollected) 
            {
                DialogueManager.StartConversation("C_3.4_Farmer_FrogRiddle");           //start second riddle (frog)
            }
            //if first AND the second animal was delivered.. Riddle won
            if (DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected && DeliveryRiddle.Instance.animalToDeliver_02.animalScriptableObject.isCollected) 
            {
                DialogueManager.StartConversation("C_3.7_Farmer_GivingReddish");           //give reward
                DeliveryRiddle.Instance.raddish.SetActive(true);
                QuestPage_1.Instance.FinishedTask(QuestPage_1.Instance.p4_doneImage);
               
            }

        }
        else if (!animalScriptableObject.isRight)   //if the wrong animal was delivered
        {
            //Debug.Log("This is the wrong animal");

            StartCoroutine(RespawnAnimal());

            //if the first animal wasnt delivered yet.. give easy hint for animal 1
            if (!DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected) 
            {
                DialogueManager.StartConversation("C_3.3_Farmer_EasierBeeRiddle");
            }
            //if first animal is already collected and the second animal was NOT.. give easy hint for animal 2
            else if (DeliveryRiddle.Instance.animalToDeliver_01.animalScriptableObject.isCollected && !DeliveryRiddle.Instance.animalToDeliver_02.animalScriptableObject.isCollected)    
            {
                DialogueManager.StartConversation("C_3.6_Farmer_EasierFrogRiddle");
                
            }
           
        }
    }
    IEnumerator RespawnAnimal()
    {
        
        yield return new WaitForSeconds(1);
        GameObject go = Instantiate(glitterEffectWrong, this.gameObject.transform.position, Quaternion.identity) as GameObject;        //instantiate glitter prefab
        go.transform.parent = this.gameObject.transform;
        followPlayer = false;
        //sparkle effect... ?
        yield return new WaitForSeconds(2);
        this.gameObject.transform.position = respawnPoint.transform.position;
        Destroy(go);
    }
    IEnumerator StopFollow()
    {
        yield return new WaitForSeconds(1);
        //sparkle effect... ?
        followPlayer = false;
        //heavier sparkle for showing its the right one and done delivering..
    }

    //animal follow function
    private void DoFollow()
    {
       
        if (followPlayer)
        {
           

            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      //follow
            }
            
        }
        else
        {
            return;
        }
    }
    //when pressing sprite button..
    public void NegateFollow()              
    {
     //   if (DialogueManagerM.Instance.riddleStart_1 == true)            //if farmer riddle started..
     //   {
            if (!followPlayer)
            {
                
                followPlayer = true;
             PlayAnimalSound();
            }
            else if (followPlayer)
            {
                followPlayer = false;
            }
      //  }
       
    }

    //if player is close, activate sprite button
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DialogueManagerM.Instance.riddleStart_1 == true)            //if farmer riddle started..
        {
            if (!this.animalScriptableObject.isCollected)               //if this animal is not collected (not delivered already on spot)..
            {
                // ADD LINE -> IF has talked to farmer npc at least once= true , then do the next lines..
                if (other.CompareTag("Player") && M_Potion.Instance.hasCharmPotionActive)           //if player its the player and if charm potion is active..
                {
                    spriteButton.SetActive(true);                                                   //activate follow button
                }
            }
           
        }
    }

    //if player is not close, disable sprite button
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteButton.SetActive(false);
        }
    }

    private void PlayAnimalSound()
    {
        if (this.animalScriptableObject.animalType == "Bee")
        {
            AudioManager.PlaySound("Bee_SFX");
        }

        if (this.animalScriptableObject.animalType == "Frog")
        {
            AudioManager.PlaySound("MagicFrog_SFX");
        }
        if (this.animalScriptableObject.animalType == "Chicken")
        {
            AudioManager.PlaySound("Chicken_SFX");
        }
        if (this.animalScriptableObject.animalType == "Cow")
        {
            AudioManager.PlaySound("Cow_SFX");
        }
    }
}
