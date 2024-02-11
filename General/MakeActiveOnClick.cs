using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveOnClick : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToSetActive;
    [SerializeField] private bool consumable;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        _gameObjectToSetActive.SetActive(true);
        if (consumable == true)
        {
            Destroy(this.gameObject);
        }
    }
}
