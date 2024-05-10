using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField] private float scaleChange;
    [SerializeField]
    private GameObject _inventoryPanel;
    private Animator _inventoryButtonAnimator;
    private PlayerMovement _playerMovement;
    [SerializeField]
    private GameObject _inventoryButtonObject;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _defaultItemClip;

    [SerializeField] private InventoryButton _inventoryButton;


    void Start()
    {
        _inventoryButtonAnimator = _inventoryButtonObject.GetComponent<Animator>();
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (_audioSource == null)
        {
            GetComponent<AudioSource>();
        }

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
        // _playerMovement.MoveableFalse();
    }

    public void PauseGamePlay()
    {
        _playerMovement.MoveableFalse();
        _inventoryPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        // _playerMovement.MoveableTrue();
    }

    public void PulseInventoryButton()
    {
        _inventoryButtonAnimator.SetTrigger("Pulse");
    }

    public void PlayObjectSound(AudioClip newClip)
    {
        _audioSource.clip = newClip;
        _audioSource.Play();

    }

    public void PlayDefaultSound()
    {
        _audioSource.clip = _defaultItemClip;
        _audioSource.Play();

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
        _inventoryButtonObject.SetActive(true);
        _inventoryButton.ShowingInventory();

    }

    public void ShowInventory()
    {

        if (_inventoryPanel.activeSelf == true)
        {
            _inventoryButton.ShowingInventory();
            _inventoryPanel.SetActive(false);
            // _playerMovement.MoveableTrue();


        }
        else
        {
            _inventoryButton.HidingInventory();
            _inventoryPanel.SetActive(true);
            // _playerMovement.MoveableFalse();


        }
    }


}
