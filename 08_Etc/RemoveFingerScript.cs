using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFingerScript : MonoBehaviour
{
    private GameObject fingerScript;
    // Start is called before the first frame update
    void Start()
    {
        fingerScript = GameObject.FindGameObjectWithTag("ToDestroy");
        Destroy(fingerScript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
