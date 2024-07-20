using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


/// <summary>
/// SCRIPT on overcat, to hold main vars and enable the sprite button when close
/// </summary>
public class NPCtalkSpriteButton : MonoBehaviour
{
    public GameObject talkSpriteButton;

    


    private void Start()
    {
        talkSpriteButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )           //if player close to house and night potion is collected..
        {
            talkSpriteButton.SetActive(true);
            //sleepInteractButton.gameObject.SetActive(true);
            
        }
    }


    //if player out of range from cat house, deactivate UI button
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkSpriteButton.SetActive(false);
            //sleepInteractButton.gameObject.SetActive(false);

            
        }
    }
}
