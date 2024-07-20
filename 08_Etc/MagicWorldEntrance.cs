using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicWorldEntrance : MonoBehaviour
{

    public GameObject player;
    public GameObject magicMazeSpawnPoint;
    // Start is called before the first frame update



    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered MagicMaze Area");
            player.transform.position = magicMazeSpawnPoint.transform.position;
           // SceneManager.LoadScene("03_MagicMaze");
        }
    }


    //public void LoadTheMagicMaze()
    //{
    //    SceneManager.LoadScene("TestMagicMaze");
    //}
}
