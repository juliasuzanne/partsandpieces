using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] notes;
    [SerializeField] private int playerNum = 0;
    private int[] currentSongArray;
    [SerializeField] private CaveSaveSettings _saveSettings;
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
        playerNum = 0;
        _saveSettings.LoadGame();
        // playerOrder = _saveSettings.GetSong();
        // if (playerOrder.length == 0)
        // {
        //     playerOrder.length = 40;
        // }
        currentSongArray = order;
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
        for (int i = 0; i < currentSongArray.Length; i++)
        {
            GameObject currentNote = Instantiate(notes[currentSongArray[i]], new Vector2(currentX, currentY + notes[currentSongArray[i]].GetComponent<INoteable>().GetOffset()), Quaternion.identity);

            currentX += _pause;
            currentNote.transform.parent = this.transform;

        }

    }

    public void MakeSongActive()
    {
        songActive = true;
    }

    public void SwitchToPlayerSong()
    {
        currentSongArray = playerOrder;
    }

    public void SwitchToHeartAndSoul()
    {
        currentSongArray = order;
    }




    public void AddToPlayerOrder(int key)
    {
        if (playerNum < 40)
        {
            playerOrder[playerNum] = key;
            playerNum = playerNum + 1;
        }
        else
        {
            Debug.Log("That's the maximum");
        }


    }

    public void FinishSong()
    {
        playerOrder[playerNum] = 9;
        _saveSettings.SaveSong(playerOrder);

    }
}