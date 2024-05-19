using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private CaveSaveSettings _saver;
    private float delay;
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

    public void ChangeDelayTime(float newDelay)
    {
        delay = newDelay;
    }
    public void LoadScene(int scene)
    {
        _saver.SaveGame();
        _saver.LoadGame();
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneViaString(string scene)
    {
        _saver.SaveGame();
        _saver.LoadGame();

        switch (scene)
        {
            case "lab":
                {
                    SceneManager.LoadScene(3);
                    break;
                }
            case "maze":
                {
                    SceneManager.LoadScene(4);
                    break;
                }
            case "face":
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            case "exterior":
                {
                    SceneManager.LoadScene(7);
                    break;
                }
            case "lookoutwindow":
                {
                    SceneManager.LoadScene(5);
                    break;
                }
            case "stair":
                {
                    SceneManager.LoadScene(9);
                    break;
                }
            case "drawing":
                {
                    SceneManager.LoadScene(13);
                    break;
                }
            case "cave":
                {
                    SceneManager.LoadScene(8);
                    break;
                }
            case "babymind":
                {
                    SceneManager.LoadScene(10);
                    break;
                }
            case "exteriorwindow":
                {
                    SceneManager.LoadScene(6);
                    break;
                }
            case "piano":
                {
                    SceneManager.LoadScene(1);
                    break;
                }
            case "torsopuzzle":
                {
                    SceneManager.LoadScene(11);
                    break;
                }
            case "train":
                {
                    SceneManager.LoadScene(12);
                    break;
                }
            case "storage":
                {
                    SceneManager.LoadScene(14);
                    break;
                }
            case "ending":
                {
                    SceneManager.LoadScene(15);
                    break;
                }
            case "credits":
                {
                    SceneManager.LoadScene(16);
                    break;
                }

        }
    }

    public void LoadSceneNoSave(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneWithDelay(int scene)
    {
        StartCoroutine(LoadSceneCoRoutine(scene));
    }

    IEnumerator LoadSceneCoRoutine(int scene)
    {
        yield return new WaitForSeconds(delay);
        // _saver.LoadGame();
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
