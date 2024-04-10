using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SetTriggersToCall : MonoBehaviour
{
    [SerializeField] UnityEvent onTrigger;
    [SerializeField] UnityEvent onTriggerToggled;

    [SerializeField] private bool consumable;
    // Start is called before the first frame update
    public void TriggerNoMouseDown()
    {
        Debug.Log("START TRIGGERING " + transform.name);
        onTrigger.Invoke();
        Debug.Log("DONE TRIGGERING " + transform.name);

        if (consumable == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void TriggerNoMouseDownToggled()
    {
        Debug.Log("START TOGGLE TRIGGERING " + transform.name);
        onTriggerToggled.Invoke();
        Debug.Log("DONE TOGGLE TRIGGERING " + transform.name);

        if (consumable == true)
        {
            Destroy(this.gameObject);
        }
    }

}
