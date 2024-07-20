using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharmPage_2 : MonoBehaviour
{
    public GameObject charmPotionImage;
    public Sprite charmPotionCOLOR;

    public GameObject ingredientHerb1Image;
    public Sprite ingredientHerb1ImageCOLOR;

    public static CharmPage_2 Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImageIngredient()
    {
        ingredientHerb1Image.GetComponent<Image>().sprite = ingredientHerb1ImageCOLOR;
    }
    public void ChangeImagePotion()
    {
        charmPotionImage.GetComponent<Image>().sprite = charmPotionCOLOR;
    }
}
