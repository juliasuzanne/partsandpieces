using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] private PlayerConversant playerConversant;
        [SerializeField] private string Name;
        [SerializeField] private string objectThatTriggers;
        [SerializeField] private Sprite conversantImage;

        void Start()
        {
            // _nameObject.onNameUpdated += UpdateName();
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }

        public void ChangeDialogue(Dialogue newDialogue)
        {
            dialogue = newDialogue;
        }

        public void UpdateName(string name)
        {
            Name = name;

        }

        public string GetConversantName()
        {
            return Name;
        }


        public Sprite GetConversantImage()
        {
            return conversantImage;
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

        public void StartConversation()
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == objectThatTriggers)
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
}

