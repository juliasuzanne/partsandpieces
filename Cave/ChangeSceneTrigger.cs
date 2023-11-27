using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    private SwitchScene _sceneSwitcher;
    void Start()
    {
        _sceneSwitcher = transform.parent.GetComponent<SwitchScene>();
        if (_sceneSwitcher == null)
        {
            Debug.Log("THE SCENE SWITCHER IS NULL!");
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _sceneSwitcher.CaveFall();
        }
    }
}
