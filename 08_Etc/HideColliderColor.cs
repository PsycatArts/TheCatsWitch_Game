using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script to hide the tilemap collider colors when the game starts
/// it basically gets the renderer component (the visual render) and sets it to inactive (hidden)
/// </summary>
public class HideColliderColor : MonoBehaviour
{

    private TilemapRenderer tilemapRender;

    private void Awake()
    {
        tilemapRender = GetComponent<TilemapRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tilemapRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
