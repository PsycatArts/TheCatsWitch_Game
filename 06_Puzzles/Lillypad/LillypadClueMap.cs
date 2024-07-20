using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LillypadClueMap : MonoBehaviour
{
    public static LillypadClueMap MapInstance;
    // Start is called before the first frame update

    
    void Start()
    {
        MapInstance = this;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
