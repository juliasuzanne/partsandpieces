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
    private GameObject _inventoryButtonObject;
    private InventoryButton _inventoryButton;


    void Start()
    {

        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _inventoryButton = _inventoryButtonObject.GetComponent<InventoryButton>();

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
        _inventoryButton.ShowingInventory();
        _inventoryPanel.SetActive(false);
        _playerMovement.MoveableTrue();
    }

    public void HideInventoryOnly()
    {
        _inventoryButton.ShowingInventory();
        _inventoryPanel.SetActive(false);
    }

    public void HideInventoryWithButton()
    {
        _inventoryButtonObject.SetActive(false);
        _inventoryPanel.SetActive(false);
    }


    public void ShowInventoryButton()
    {
        _inventoryButtonObject.SetActive(false);

    }

    public void ShowInventory()
    {

        if (_inventoryPanel.activeSelf == true)
        {
            _inventoryButton.ShowingInventory();
            _inventoryPanel.SetActive(false);
            _playerMovement.MoveableTrue();


        }
        else
        {
            _inventoryButton.HidingInventory();
            _inventoryPanel.SetActive(true);
            _playerMovement.MoveableFalse();


        }
    }


}
