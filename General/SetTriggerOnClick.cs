using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetTriggerOnClick : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] private bool consumable;

    void OnMouseDown()
    {
        onTrigger.Invoke();
        if (consumable == true)
        {
            Destroy(this.gameObject);
        }

    }

}



// [SerializeField]
// private string _triggerName;
// [SerializeField]
// private string _outsideTriggerName;
// [SerializeField]
// private float _secondsToDestroy;
// [SerializeField]
// private bool _destroy = true;

// private Animator _animator;
// [SerializeField] Animator outsideAnimator;
// [SerializeField] GameObject _inventoryObject;
// [SerializeField] Inventory _playerInventory;
// // Start is called before the first frame update
// void Start()
// {
//     _animator = GetComponent<Animator>();
//     _playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
// }

// // Update is called once per frame
// void OnMouseDown()
// {
//     if (_triggerName != null)
//     {
//         _animator.SetTrigger(_triggerName);
//     }

//     if (_outsideTriggerName != null)
//     {
//         outsideAnimator.SetTrigger(_triggerName);
//     }

//     if (_inventoryObject != null)
//     {
//         _playerInventory.AddItemToInventory(_inventoryObject);

//     }
//     if (_destroy == true)
//     {
//         Destroy(this.gameObject, _secondsToDestroy);
//     }

// }

