using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnip : MonoBehaviour
{
    public SpriteRenderer turnipObj;
    public Sprite turnipSprite01;
    public Sprite turnipSprite02;
    public Sprite turnipSprite03;
    public Sprite turnipSprite04;

    public Knife knife;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTurnipSprite(knife.cutCount);
    }


    void ChangeTurnipSprite(int cutCounter)
    {
        if (cutCounter == 1)
        {
            turnipObj.sprite = turnipSprite01;
        }
        else if (cutCounter == 2)
        {
            turnipObj.sprite = turnipSprite02;
        }
        else if (cutCounter == 3)
        {
            turnipObj.sprite = turnipSprite03;
        }
        else if (cutCounter == 4)
        {
            turnipObj.sprite = turnipSprite04;
        }
    }
}
