using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainWorldEntrance : MonoBehaviour
{

    public GameObject player;
    public GameObject mainWorldSpawnPoint;



    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
         
            Debug.Log("Entered MainWorld Area");
            player.transform.position = mainWorldSpawnPoint.transform.position;
        }
    }

}
