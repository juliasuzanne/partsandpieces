using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] private bool freezeOnTalk;
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] private PlayerConversant playerConversant;
        [SerializeField] private string Name;
        [SerializeField] private string objectThatTriggers;
        [SerializeField] private Sprite conversantImage;

        [SerializeField] private Dialogue startingDialogue;

        void Start()
        {
            startingDialogue = dialogue;
            // _nameObject.onNameUpdated += UpdateName();
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }

        public bool FreezeOnTalk()
        {
            return freezeOnTalk;
        }

        public void SetCurrentDialogue()
        {
            startingDialogue = dialogue;
        }

        public void ChangeDialogue(Dialogue newDialogue)
        {
            SetCurrentDialogue();
            dialogue = newDialogue;
        }

        public void GoBackToStartingDialogue()
        {
            ChangeDialogue(startingDialogue);
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
            else if (this == null)
            {
                Debug.Log("THIS IS NULL");
            }

            else
            {
                Debug.Log("THIS" + this);
                Debug.Log("DIALOGUE" + dialogue);
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

