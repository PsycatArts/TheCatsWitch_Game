using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SCRIPT TO OPEN/CLOSE JOURNAL ON UI BUTTON CLICK
/// </summary>
public class JournalButton : MonoBehaviour
{
    public GameObject journalBook;

    public void Start()
    {
        journalBook.GetComponent<GameObject>();
    }

    public void OpenCloseJournal()
    {
        if (!journalBook.activeSelf)
        {
            journalBook.SetActive(true);
            Debug.Log("Opening Journal");
        }
        else if (journalBook.activeSelf)
        {

            journalBook.SetActive(false);
            Debug.Log("Closing Journal");
        }
    }
}
