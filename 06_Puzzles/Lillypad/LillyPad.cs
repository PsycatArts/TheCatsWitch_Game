using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LillyPad : MonoBehaviour
{
    //private SpriteRenderer lillyPadColor;
    //private Color m_color;
    //private GameObject player;
    private PlayerMovement playermovement;
    private float waitingTime;

    private GameObject lillypadRespawn;
    public bool playerdidFall;

    public Frog frog1;
    public Frog frog2;

    // Start is called before the first frame update
    void Start()
    {
        playermovement = PlayerInfo.instance.playerobject.GetComponent<PlayerMovement>();
        playerdidFall = false;
        lillypadRespawn = GameObject.FindGameObjectWithTag("LillypadRespawn");
    }

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stepped on wrong lillypad");
            playerdidFall = true;
            StartCoroutine(WaitForAMoment());

            frog1.followPlayer = false;
            frog2.followPlayer = false;


            if (!DialogueManagerM.Instance.lillypadFail_5)
            {
                DialogueManager.StartConversation("H_2.5_FailingLilypads");
                DialogueManagerM.Instance.lillypadFail_5 = true;
            }
        }
    }

    IEnumerator WaitForAMoment()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);      //change color as indicator for stepping on wrong
        //player.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints.FreezePositionY;
        playermovement.moveSpeed = 0f;
        
        yield return new WaitForSeconds(1);
        AudioManager.PlaySound("LillypadWaterSplash");
        //yield return new WaitForSeconds(0.5f);

        PlayerInfo.instance.playertransform.position = lillypadRespawn.transform.position;
        playerdidFall = false;


        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;                 //remove sprite
        //this.gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = true;     //activate the hard collider of lillypad
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);     //activate the hard collider of lillypad

        playermovement.moveSpeed = 2f;
        //this.gameObject.SetActive(false);             //delete the lillypad but need to place a collider for this so player doesnt walk on water

    }
}
