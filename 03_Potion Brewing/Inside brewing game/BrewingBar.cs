using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;


public class BrewingBar : MonoBehaviour
{

    public GameObject bar;
    public int time;            //time it needs to fill up 
    public float timer = 0f;    //timer to keep track of time for tapping moment

    private bool m_start = false;
    private bool didStartAlr = false;

    public int startTime;            //time it needs to fill up 
    public float startTimer = 0f;    //timer to keep track of time for tapping moment

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_start && !didStartAlr)
        {
            timer += Time.deltaTime;
            AnimateBar();
            didStartAlr = true;
        }
        


        startTimer += Time.deltaTime;
        if (startTimer >= startTime)
        {
            m_start = true;

        }
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }
}
