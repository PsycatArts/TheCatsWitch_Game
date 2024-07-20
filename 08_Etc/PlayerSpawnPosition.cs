using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPosition : MonoBehaviour
{
    //public Scene magicMazeScene;
    //private string sceneName;
    // Start is called before the first frame update

    public Transform spawnPos1;
    public Transform spawnPos2;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //at start of this script, check which scene is active
        if (SceneManager.GetActiveScene().name == "02_MainWorld")
        {
            player.transform.position = spawnPos1.position;
            Debug.Log("CURRENT SCENE IS MAIN WORLD");
        }
        if (SceneManager.GetActiveScene().name == "03_MagicMaze")
        {
            player.transform.position = spawnPos2.position;


            Debug.Log("CURRENT SCENE IS MAGIC MAZE");
        }
    }

    // Update is called once per frame
    void Update()
    {
      

       
    }
}
