using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetTriggerOnExit : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] private bool consumable;
    [SerializeField] private Collider2D targetCollider;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other);
        if (other == targetCollider)
        {
            onTrigger.Invoke();
            if (consumable == true)
            {
                Destroy(this.gameObject);
            }
        }


    }

}


