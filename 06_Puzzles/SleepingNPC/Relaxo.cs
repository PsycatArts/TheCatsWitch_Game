using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relaxo : MonoBehaviour
{
    public GameObject spriteButton;

    public static Relaxo Instance;

    //private Animator relaxoAnim;

    private void Start()
    {
        Instance = this;
        spriteButton.SetActive(false);
        //relaxoAnim = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.PlaySound("catSnoring");
        if (other.CompareTag("Player") && M_Potion.Instance.hasCharmPotionActive)           //if player close to house and night potion is collected..
        {

            spriteButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteButton.SetActive(false);
        }
    }


    public void MoveRelaxoOutOfWay()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        Debug.Log("Moved relaxo out of ya way");
       // relaxoAnim.Play("WakeUp");
        StartCoroutine(MoveHim());
    }

    IEnumerator MoveHim()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

}
