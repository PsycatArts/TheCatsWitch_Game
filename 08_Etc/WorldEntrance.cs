using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEntrance : MonoBehaviour
{
    public string sceneToSwitchTo;

    private void OnTriggerEnter2D(Collider2D other)                 //if player enters trigger, collect item
    {
        if (other.CompareTag("Player"))
        {
            //sce
            SceneManager.LoadScene(sceneToSwitchTo);
        }
    }
}
