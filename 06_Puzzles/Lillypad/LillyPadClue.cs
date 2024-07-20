using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LillyPadClue : MonoBehaviour
{
    //public Button lillypadClueButton;
    public GameObject lillypadclueSpriteButton;
    //public GameObject clueImage;

    private void Awake()
    {
        //clueImage = GameObject.FindGameObjectWithTag("LillypadClue");
        //clueImage.SetActive(false);
        lillypadclueSpriteButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )           //if player close to house and night potion is collected..
        {
            lillypadclueSpriteButton.gameObject.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")  )
        {
            lillypadclueSpriteButton.gameObject.SetActive(false);
            //clueImage.SetActive(false);
            //LillypadClueMap.MapInstance.gameObject.SetActive(false);
            PauseMenu.Instance.lillypadClueMap.SetActive(false);
        }
    }

    public void OpenCloseClue()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        if (!PauseMenu.Instance.lillypadClueMap.activeSelf)
        {
            PauseMenu.Instance.lillypadClueMap.SetActive(true);
            //clueImage.SetActive(true);
            Debug.Log("Opening Clue");
        }
        else if (PauseMenu.Instance.lillypadClueMap.activeSelf)
        {
            PauseMenu.Instance.lillypadClueMap.SetActive(false);
           // LillypadClueMap.MapInstance.gameObject.SetActive(true);
           // clueImage.SetActive(false);
            Debug.Log("Closing Clue");
        }
    }
}
