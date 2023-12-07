using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField]
    private CaveSaveSettings _saver;


    public void FirstScene()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(0);
    }
}
