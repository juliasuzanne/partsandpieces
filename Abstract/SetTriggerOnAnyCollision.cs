using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetTriggerOnAnyCollision : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] private bool consumable;

    void OnTriggerEnter2D(Collider2D other)
    {
        onTrigger.Invoke();
    }

}


