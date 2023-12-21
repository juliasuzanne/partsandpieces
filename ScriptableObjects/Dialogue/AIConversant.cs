using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour, INameable
    {
        [SerializeField] Dialogue dialogue = null;
        private PlayerConversant playerConversant;

        public string Name { get; set; }
        [SerializeField] private string _defaultName;

        public void ChangeName(string name)
        {
            Name = name;
        }

        void Start()
        {
            Name = _defaultName;

            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
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

