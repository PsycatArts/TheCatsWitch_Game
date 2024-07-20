using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NarratorFlowermaze : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !DialogueManagerM.Instance.flowerMazeWarning_1)           //if player close to house 
        {

            DialogueManager.StartConversation("H_1.2_Flowermaze");
            DialogueManagerM.Instance.flowerMazeWarning_1 = true;
        }
    }
}
