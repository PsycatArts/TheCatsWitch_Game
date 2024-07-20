using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidBar : MonoBehaviour
{
    public Slider slider;
    public GameObject fillColor;
    private void Start()
    {
        //fillColor.GetComponent<Image>().color 
        //fillColor= fillColor.color;
    }

    private void Update()
    {
        
    }
    public void SetMaxLiquid(int liquid)
    {
        slider.maxValue = liquid;       //max value will be set to given parameter
        //slider.value = liquid;
    }

    public void SetLiquid(int liquid)
    {
        slider.value = liquid;
    }
}
