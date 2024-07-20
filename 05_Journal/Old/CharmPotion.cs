using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

/// <summary>
/// SCRIPT which sits on PotionButton. If pressed, call use function (activate effect)
/// </summary>
public class CharmPotion : MonoBehaviour
{
    public Image potionButtonVisual;
    public SpriteRenderer charmEffect;

    [HideInInspector]public bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        potionButtonVisual.GetComponent<Image>();
        charmEffect= GameObject.FindWithTag("PotionEffect").GetComponent<SpriteRenderer>();
        isActive = false;
    }

    // Update is called once per frame
    public void Use()
    {
        Debug.Log("activated charm potion");
        if (!isActive)
        {
            potionButtonVisual.color = Color.red;
            isActive = true;
            charmEffect.enabled=true;
        }
        else
        {
            potionButtonVisual.color = Color.white;
            isActive = false;
            charmEffect.enabled = false;
        }
        
    }
}
