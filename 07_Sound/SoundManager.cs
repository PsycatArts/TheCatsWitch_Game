using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public GameObject dayMusic;
    public GameObject nightMusic;
    public GameObject menuMusic;
    public GameObject brewingMusic;

    void Awake()
    {
        if (Instance != null)       //if an instance of this already exists
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;           //so instance isnt null (so we have one instance which is THIS)
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        
    }


}
