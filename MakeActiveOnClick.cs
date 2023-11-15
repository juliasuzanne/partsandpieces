using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectToSetActive;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        _gameObjectToSetActive.SetActive(true);
    }
}
