using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;
    public SaveObject so;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
    }

    public void SaveGame()
    {
        SaveManager.Save(so);
    }

    public void LoadGame()
    {
        so = SaveManager.Load();

    }

}
