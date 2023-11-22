using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConversation : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectToSetActive;
    private Animator _abovePlayerAnimator;
    // Start is called before the first frame update

    void Start()
    {
        _abovePlayerAnimator = GameObject.Find("AbovePlayer").GetComponent<Animator>();

    }
    void OnMouseDown()
    {
        _gameObjectToSetActive.SetActive(true);
        _abovePlayerAnimator.SetBool("Conversate", true);

    }

    public void ComeBackFromConversation()
    {
        _abovePlayerAnimator.SetBool("Conversate", false);

    }
}