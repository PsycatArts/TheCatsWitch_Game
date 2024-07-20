using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthPage4 : MonoBehaviour
{
    //public GameObject strengthPotionImage;
    //public GameObject ingredientPear1Image;
    //public GameObject ingredientHoney2Image;
    public GameObject ingredientSpinach3Image;
    public Sprite ingredientSpinach3ImageCOLOR;

    public static StrengthPage4 Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImageIngredient3()
    {
        ingredientSpinach3Image.GetComponent<Image>().sprite = ingredientSpinach3ImageCOLOR;
    }
}
