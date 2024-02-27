using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private CaveSaveSettings _saver;
    void Start()
    {
        _saver = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();

    }

    public void CaveFall()
    {
        _saver.SaveGame();
        Debug.Log("CAVE FALL SAVED GAME");
        SceneManager.LoadScene(1);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void FirstScene()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(0);
    }

    public void Return()
    {
        _saver.LoadGame();
        SceneManager.LoadScene(_saver.so.playerLevel);
    }

    public void About()
    {
        // _saver.SaveGame();
        // SceneManager.LoadScene(2);
    }

    public void Finish()
    {
        SceneManager.LoadScene(3);
    }




}
