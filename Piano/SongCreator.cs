using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] notes;
    [SerializeField] private int[] order;
    [SerializeField] private int[] playerOrder;
    [SerializeField] private float _pause = 0.75f;
    [SerializeField] private float currentX = -2.8f;
    [SerializeField] private float currentY = 0.54f;
    [SerializeField] private float yToAdd = 0f;
    [SerializeField] private bool songActive;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (songActive == true)
        {
            CreateSong();
        }

    }


    void CreateSong()
    {
        songActive = false;
        for (int i = 0; i < order.Length; i++)
        {
            GameObject currentNote = Instantiate(notes[order[i]], new Vector2(currentX, currentY + notes[order[i]].GetComponent<INoteable>().GetOffset()), Quaternion.identity);

            currentX += _pause;
            currentNote.transform.parent = this.transform;
        }
    }

    public void MakeSongActive()
    {
        songActive = true;
    }
}