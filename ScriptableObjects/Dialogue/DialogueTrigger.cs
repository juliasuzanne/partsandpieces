using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{

    public class DialogueTrigger : MonoBehaviour
    {
        private int count = 0;
        [SerializeField] string[] action;
        [SerializeField] UnityEvent[] onTrigger;

        public void Trigger(string actionToTrigger)
        {
            count = 0;
            foreach (string correct in action)
            {
                if (actionToTrigger == correct)
                {
                    onTrigger[count].Invoke();
                    break;
                }
                count = count + 1;
            }

        }

    }


}
