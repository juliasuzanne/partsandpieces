using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetTriggerOnExit : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] private bool consumable;
    [SerializeField] private string targetColliderName;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.name == targetColliderName)
        {
            onTrigger.Invoke();
            if (consumable == true)
            {
                Destroy(this.gameObject);
            }
        }


    }

}


