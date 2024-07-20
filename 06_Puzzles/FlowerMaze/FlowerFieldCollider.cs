using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerFieldCollider : MonoBehaviour
{
   // private GameObject player;
    private GameObject respawnPoint;
    // Start is called before the first frame update
    void Awake()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        //player = PlayerInfo.instance.playerobject;
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnFlowerMaze");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.PlaySound("BushSound");
            //SceneManager.LoadScene(Respawn);
            //player.transform.position = respawnPoint.transform.position;
            PlayerInfo.instance.playertransform.position = respawnPoint.transform.position;
        }
    }
}
