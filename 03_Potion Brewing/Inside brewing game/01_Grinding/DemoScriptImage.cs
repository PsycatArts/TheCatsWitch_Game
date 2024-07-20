//
// Fingers Gestures
// (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// SCRIPT FOR POTION BREWING STEP 1 (Draw an image on screen / grinding )
/// </summary>

namespace DigitalRubyShared
{
    /// <summary>
    /// Demo script that matches a drawn image
    /// </summary>
    public class DemoScriptImage : MonoBehaviour
    {
        /// <summary>
        /// Image script
        /// </summary>
        [Tooltip("Image gesture helper component script")]
        public FingersImageGestureHelperComponentScript ImageScript;

        /// <summary>
        /// Match particle system
        /// </summary>
        [Tooltip("Matched particle system")]
        public ParticleSystem MatchParticleSystem;

        /// <summary>
        /// Match audio source
        /// </summary>
        [Tooltip("Match audio source")]
        public AudioSource AudioSourceOnMatch;



        // public int time;            //time it needs to fill up 
        // public float timer = 0f;    //timer to keep track of time for tapping moment
        //private bool timeOver;
        // private bool messageShown;

        // public GameObject bar;

        //public int startTime;            //time it needs to fill up 
        // public float startTimer = 0f;    //timer to keep track of time for tapping moment

        //public Image panelImage;
        public GameObject panel;

        // private bool m_start = false;
        // private bool didStartAlr = false;

        public GameObject guideButton;
        public GameObject winButton;
        public GameObject failButton;

        private GameObject nightMusic;


        
        public SpriteRenderer herb;
        public Sprite grindedHerbSprite;

        private void LinesUpdated(object sender, System.EventArgs args)
        {
            Debug.LogFormat("Lines updated, new point: {0},{1}", ImageScript.Gesture.FocusX, ImageScript.Gesture.FocusY);
        }

        private void LinesCleared(object sender, System.EventArgs args)
        {
            Debug.LogFormat("Lines cleared!");
        }

        private void Start()
        {
            ImageScript.LinesUpdated += LinesUpdated;
            ImageScript.LinesCleared += LinesCleared;

            //panel.SetActive(false);
            nightMusic = GameObject.FindGameObjectWithTag("NightMusic");
            nightMusic.SetActive(false);

            M_Player.Instance.PlayerInvisible();

           
        }

        private void Update()
        {
        }
        private void LateUpdate()
        {
            // TODO: Do something with the match
            // You could get a texture from it:
            // Texture2D texture = FingersImageAutomationScript.CreateTextureFromImageGestureImage(match);

        }

        //method to call when time is over
        public void Done()
        {
            
            // Debug.Log("Game is done");
            ImageGestureImage match = ImageScript.CheckForImageMatch();     //addon magic

            if (match != null)                          //if matching drawing found
            {
                    herb.sprite = grindedHerbSprite;
                    MatchParticleSystem.Play();
                    AudioManager.PlaySound("SuccessSFX");
                    StartCoroutine(GrindedHerb());

                guideButton.SetActive(false);
                    winButton.SetActive(true);              //activate the winning button

            }
            else
            {                                           //if no matching drawing found (player didnt grind properly)
                panel.SetActive(true);                //activate the win/lose panel 
                guideButton.SetActive(false);
                failButton.SetActive(true);             //activate fail button to try again
                    
                    AudioManager.PlaySound("BrewingFail_Sound");
            }

            
        }

        IEnumerator GrindedHerb()
        {
            yield return new WaitForSeconds(2);
            panel.SetActive(true);                //activate the win/lose panel 
        }

    }
}
