using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;
        private PlayerConversant playerConversant;

        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }

        public string GetConversantName()
        {
            return conversantName;
        }

        private void OnMouseDown()
        {
            if (dialogue == null)
            {
                Debug.Log("AI Conversant dialogue is NULL");
            }

            else
            {
                playerConversant.StartDialogue(this, dialogue);
            }

        }


    }
}

