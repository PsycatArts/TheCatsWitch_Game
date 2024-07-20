using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject cauldronPanel;
    public GameObject cauldronPanelMissingIngredient;
    public GameObject cauldronPanelBrewingStep1;
    public GameObject cauldronPanelBrewingStep2;


    public GameObject tooDarkPanel;
    public GameObject lillypadClueMap;

    public static PauseMenu Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);

        lillypadClueMap.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        
    }


    //method to call when pauseButton is pressed
    public void PauseTheGame()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    //methods used by/within PauseButton Method
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
     void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //method to call on "back to menu" 
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("00_MainMenu");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;


        //destroy all things to have a fresh game

        Destroy(GameObject.FindGameObjectWithTag("PotionInventory"));
        Destroy(GameObject.FindGameObjectWithTag("CollectManager"));
        Destroy(GameObject.FindGameObjectWithTag("DialogueManager"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("FSMpotion"));
        Destroy(GameObject.FindGameObjectWithTag("FSMplayer"));
        Destroy(GameObject.FindGameObjectWithTag("FSMworld"));
        Destroy(GameObject.FindGameObjectWithTag("LightManager"));
        Destroy(this.gameObject);
    }
    //method to call on quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    //to call when pressing OK button
    public void DeactivateBrewingPanel()
    {
        cauldronPanelMissingIngredient.SetActive(false);
        cauldronPanelBrewingStep1.SetActive(false);
        cauldronPanelBrewingStep2.SetActive(false);
        cauldronPanel.SetActive(false);
    }

    public void BrewingStep1()
    {
        SceneManager.LoadScene("04_PotionBrewingStep_1");
        DeactivateBrewingPanel();
    }

}
