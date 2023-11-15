using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _inventoryPanel;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGameMenu();
        }
    }

    public void PauseGameMenu()
    {
        _pausePanel.SetActive(true);
        _playerMovement.MoveableFalse();
    }

    public void PauseGamePlay()
    {
        _playerMovement.MoveableFalse();
        _inventoryPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        _playerMovement.MoveableTrue();
    }


    public void HideInventory()
    {
        _inventoryPanel.SetActive(false);
        _playerMovement.MoveableTrue();

    }

    public void ShowInventory()
    {

        if (_inventoryPanel.activeSelf == true)
        {
            _inventoryPanel.SetActive(false);
            _playerMovement.MoveableTrue();


        }
        else
        {
            _inventoryPanel.SetActive(true);
            _playerMovement.MoveableFalse();


        }
    }


}
