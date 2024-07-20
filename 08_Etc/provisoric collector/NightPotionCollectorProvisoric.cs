using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightPotionCollectorProvisoric : MonoBehaviour
{
   // public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.PlaySound("SpriteButtonClickSound");
            CollectManagerProvisoric.Instance.hasNightPotion = true;
            //collectManager.hasCollectedHerbs = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //StartCoroutine(TemporaryPanel());
            
        }
    }

    //IEnumerator TemporaryPanel()
    //{
    //    yield return new WaitForSeconds(1);
    //    panel.SetActive(true);
    //    yield return new WaitForSeconds(5);
    //    panel.SetActive(false);
    //}
}
