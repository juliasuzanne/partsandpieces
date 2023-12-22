using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour, IRaycastable
    {
        [SerializeField] Dialogue dialogue = null;
        private PlayerConversant playerConversant;
        [SerializeField] private string Name;

        void Start()
        {
            // _nameObject.onNameUpdated += UpdateName();
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }

        public void UpdateName(string name)
        {
            Name = name;

        }

        public string GetConversantName()
        {
            return Name;
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

