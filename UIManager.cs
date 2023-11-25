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
    [SerializeField]
    private InventoryButton _inventoryButton;

    void Start()
    {

        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        _inventoryButton.HidingInventory();
        _inventoryPanel.SetActive(false);
        _playerMovement.MoveableTrue();
    }

    public void HideInventoryOnly()
    {
        _inventoryButton.HidingInventory();
        _inventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {

        if (_inventoryPanel.activeSelf == true)
        {
            _inventoryButton.HidingInventory();
            _inventoryPanel.SetActive(false);
            _playerMovement.MoveableTrue();


        }
        else
        {
            _inventoryButton.ShowingInventory();
            _inventoryPanel.SetActive(true);
            _playerMovement.MoveableFalse();


        }
    }


}
