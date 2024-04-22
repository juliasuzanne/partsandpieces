using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : MonoBehaviour, IGrowable
{
    [SerializeField] private CaveSaveSettings saveSettings;
    [SerializeField] private TimeManager tm;

    public float startingTime { get; set; }
    public SpriteRenderer sp { get; set; }
    public Sprite[] sprites { get; set; }
    public float growingTime { get; set; }
    public bool growing { get; set; }

    [SerializeField] private float j_startingTime;
    [SerializeField] public SpriteRenderer j_sp;
    [SerializeField] public Sprite[] j_sprites;
    [SerializeField] public float j_growingTime = 0;
    public bool j_growing = false;



    // Start is called before the first frame update
    void Start()
    {
        j_sp = GetComponent<SpriteRenderer>();
        startingTime = j_startingTime;
        sp = j_sp;
        sprites = j_sprites;
        growingTime = j_growingTime;
        growing = j_growing;
        saveSettings = FindObjectOfType<CaveSaveSettings>();
        tm = FindObjectOfType<TimeManager>();
        if (growing == true)
        {
            growingTime = saveSettings.so.time - startingTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (j_growing == true)
        {
            j_growingTime = j_growingTime += Time.deltaTime;
            if (j_growingTime > 40)
            {
                if (j_sprites[1] != null)
                {
                    j_sp.sprite = j_sprites[1];

                }

            }
            else if (j_growingTime > 20)
            {
                if (j_sprites[0] != null)
                {
                    j_sp.sprite = j_sprites[0];

                }
            }

        }


    }

    public void SetStartingTime()
    {
        j_startingTime = tm.GetTime();
        BoxCollider2D starter = GetComponent<BoxCollider2D>();
        starter.enabled = false;
        j_growing = true;

    }


}
