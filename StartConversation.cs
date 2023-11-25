using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConversation : MonoBehaviour, INameable
{
    [SerializeField]
    private GameObject _gameObjectToSetActive;
    public string Name { get; set; }
    private Animator _abovePlayerAnimator;
    private bool _conversable = true;
    private CaveSaveSettings _caveSaveSettings;
    // Start is called before the first frame update

    void Start()
    {
        _abovePlayerAnimator = GameObject.Find("AbovePlayer").GetComponent<Animator>();
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();

    }
    void OnMouseDown()
    {
        if (_conversable == true)
        {
            _gameObjectToSetActive.SetActive(true);
            _abovePlayerAnimator.SetBool("Conversate", true);
            _conversable = false;

        }



    }

    public void ComeBackFromConversation()
    {
        _abovePlayerAnimator.SetBool("Conversate", false);
        _conversable = false;
        Name = _caveSaveSettings.so.rockName;

    }
}