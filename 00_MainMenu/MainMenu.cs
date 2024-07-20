using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenu Button script for scene switching
/// </summary>
public class MainMenu : MonoBehaviour
{

    private bool hasPressedAlr;

    private void Start()
    {
        hasPressedAlr = false;
    }
    public void ExitButton()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        if (!hasPressedAlr)
        {
            hasPressedAlr = true;

            AudioManager.PlaySound("SpriteButtonClickSound");
            SceneManager.LoadScene("02_MainWorld");     //!! REPLACE THIS WITH ACTUAL SCENE LATER:  02_MainWorld
            Debug.Log("Start Game");
        }
        
    }

    public void StartBrewingGame()
    {
        AudioManager.PlaySound("SpriteButtonClickSound");
        SceneManager.LoadScene("P1_PotionBrewingStep_1");
    }
}
