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
    public int id { get; set; }


    [SerializeField] private float j_startingTime;
    [SerializeField] private SpriteRenderer j_sp;
    [SerializeField] private Sprite[] j_sprites;
    [SerializeField] private int j_id;
    [SerializeField] private float j_growingTime = 0;
    private bool j_growing = false;

    public int GetID()
    {
        return j_id;
    }
    public float GetStartTime()
    {
        return j_startingTime;
    }

    public void ChangeStartTime(float newTime)
    {
        j_startingTime = newTime;
    }
    public float GetGrowTime()
    {
        return j_growingTime;
    }

    public void ChangeGrowTime(float newTime)
    {
        j_growingTime = newTime;
    }
    public void ChangeGrowing()
    {
        j_growing = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        id = j_id;
        j_startingTime = 0;
        j_growing = true;
        j_growingTime = 0;
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
            growingTime = tm.GetTime() - startingTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (j_growing == true)
        {
            j_growingTime = j_growingTime - j_startingTime;
            j_growingTime = j_growingTime += tm.GetTotalTime();
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
        j_startingTime = tm.GetTotalTime();
        // BoxCollider2D starter = GetComponent<BoxCollider2D>();
        // starter.enabled = false;
        j_growing = true;

    }


}
