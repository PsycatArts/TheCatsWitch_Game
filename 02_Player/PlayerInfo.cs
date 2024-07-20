using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;          //make singleton and accessable frome verywhere

    public GameObject playerobject;
    public SpriteRenderer playersprite;
    public Transform playertransform;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);




        //playerObject = this.gameObject;
        // playersprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
