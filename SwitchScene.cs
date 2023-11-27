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
        SceneManager.LoadScene(2);
        _saver.LoadGame();
    }



}
