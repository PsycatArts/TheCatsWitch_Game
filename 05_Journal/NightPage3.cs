using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightPage3 : MonoBehaviour
{

    public GameObject nightPotionImage;
    public Sprite nightPotionImageCOLOR;

    public GameObject ingredientHerb1Image;
    public Sprite ingredientHerb1ImageCOLOR;

    public GameObject ingredientRaddish2Image;
    public Sprite ingredientRaddish2ImageCOLOR;

    public static NightPage3 Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImageIngredient1()
    {
        ingredientHerb1Image.GetComponent<Image>().sprite = ingredientHerb1ImageCOLOR;
    }
    public void ChangeImageIngredient2()
    {
        ingredientRaddish2Image.GetComponent<Image>().sprite = ingredientRaddish2ImageCOLOR;
    }
    public void ChangeImagePotion()
    {
        nightPotionImage.GetComponent<Image>().sprite = nightPotionImageCOLOR;
    }
}
