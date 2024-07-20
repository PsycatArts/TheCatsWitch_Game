using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NarratorMazeEnter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !DialogueManagerM.Instance.magicMazeEnter_3)           //if player close to house 
        {

            DialogueManager.StartConversation("H_2.1_InMaze");
            DialogueManagerM.Instance.magicMazeEnter_3 = true;
        }
    }
}
