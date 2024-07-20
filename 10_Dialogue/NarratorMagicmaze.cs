using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NarratorMagicmaze : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !DialogueManagerM.Instance.magicMazeWarning_2 &&CollectManagerProvisoric.Instance.hasCharmPotion)         
        {
            DialogueManager.StartConversation("H_1.6_LockedMaze");
            DialogueManagerM.Instance.magicMazeWarning_2 = true;
        }
    }
}
