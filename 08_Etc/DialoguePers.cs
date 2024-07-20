using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePers : MonoBehaviour
{
    public static DialoguePers Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
