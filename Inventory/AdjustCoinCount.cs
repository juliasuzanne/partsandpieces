using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustCoinCount : MonoBehaviour
{
    [SerializeField] private Text coinText;
    private CaveSaveSettings _saveManager;
    private AudioSource _audioSource;
    [SerializeField] private Text enteredCoinsText;
    [SerializeField] private AudioClip noMoneyClip;
    [SerializeField] private AudioClip getClip;
    [SerializeField] private SetBoolNoTrigger _animateCoinDrop;
    [SerializeField] private SetBoolNoTrigger _animateTicketCreate;
    [SerializeField] private GameObject ticket;


    // Start is called before the first frame update
    void Start()
    {
        _saveManager = FindObjectOfType<CaveSaveSettings>();
        coinText.text = _saveManager.so.coinCount.ToString();
        _audioSource = GetComponent<AudioSource>();
        if (enteredCoinsText != null)
        {
            enteredCoinsText.text = "Coins Entered: " + _saveManager.so.enteredCoinsCount.ToString() + "/12";
        }
    }

    public void AddCoin()
    {
        _saveManager.AddCoin();
        coinText.text = _saveManager.so.coinCount.ToString();
        _audioSource.clip = getClip;
        _audioSource.Play();

    }


    public void RemoveCoin()
    {
        if (_saveManager.so.coinCount > 0)
        {
            _saveManager.RemoveCoin();
            _saveManager.so.enteredCoinsCount = _saveManager.so.enteredCoinsCount + 1;
            _animateCoinDrop.SetAnimTrigger("DropCoin");
            coinText.text = _saveManager.so.coinCount.ToString();
            enteredCoinsText.text = "Coins Entered: " + _saveManager.so.enteredCoinsCount.ToString() + "/12";
            if (_saveManager.so.enteredCoinsCount == 12)
            {
                _animateTicketCreate.SetAnimTrigger("GetTicket");
                _saveManager.so.hasTicket = true;
                _saveManager.so.enteredCoinsCount = 0;
                ticket.SetActive(true);
            }
        }
        else
        {
            _audioSource.clip = noMoneyClip;
            _audioSource.Play();
        }


    }

}
