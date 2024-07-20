using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPersistency : MonoBehaviour
{
    public static LightPersistency Instance;
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

}
