using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrewingButton : MonoBehaviour
{
    public BrewingBar brewingbar;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI failText;
    // Start is called before the first frame update
    void Start()
    {
        brewingbar.GetComponent<BrewingBar>();
        winText.GetComponent<TextMeshProUGUI>();
        failText.GetComponent<TextMeshProUGUI>();
    }

    public void Brew()
    {
        if (brewingbar.timer >= 3 && brewingbar.timer<=4 )       //after 3 seconds its fine
        {
            winText.enabled = true;
            failText.enabled = false;
            Debug.Log("Success");
        }
        else if (brewingbar.timer <= 2 || brewingbar.timer>4)      //if clicked under 2 secs, its lost
        {
            failText.enabled = true;
            winText.enabled = false ;
            Debug.Log("You lost");
        }
    }
}
