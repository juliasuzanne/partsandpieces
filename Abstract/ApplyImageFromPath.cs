using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System.IO;


public class ApplyImageFromPath : MonoBehaviour
{
    private string testSprite = "/Users/juliagrimes/Documents/Unity/PartsAndPieces/Assets/Snapshots/snap_512x512_2024-03-01_09-49-12.png";
    private string testSprite2 = "Snapshots/snap_512x512_2024-03-01_09-27-23";
    private SpriteRenderer sp;
    [SerializeField] private CaveSaveSettings _saveSettings;
    private Sprite newSprite;
    void Start()
    {
        // _saveSettings.LoadGame();
        sp = GetComponent<SpriteRenderer>();
        newSprite = Resources.Load<Sprite>(_saveSettings.SandwichPath1());
        sp.sprite = newSprite;
        // newSprite = Resources.Load<Sprite>("Snapshots/snap_512x512_2024-03-01_09-27-23");
        // sp.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UpdateSprite()
    {
        newSprite = Resources.Load<Sprite>(testSprite2);
        sp.sprite = newSprite;
        Debug.Log(_saveSettings.SandwichPath1());
    }
}
