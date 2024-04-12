using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Dialogue
{


    public class PlayerConversant : MonoBehaviour
    {
        Dialogue currentDialogue;
        AIConversant currentConversant = null;
        [SerializeField] private Sprite myImage;
        [SerializeField] Dialogue testDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;
        [SerializeField] private string Name;
        [SerializeField] private GameObject DialogueUi;
        public event Action onConversationUpdated;

        public void UpdateName(string name)
        {
            Name = name;
        }
        // IEnumerator Start()
        // {
        //     yield return new WaitForSeconds(2f);
        //     StartDialogue(testDialogue);
        // }

        public void StartDialogue(AIConversant newConversant, Dialogue newDialogue)
        {
            currentConversant = newConversant;
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            TriggerEnterAction();
            onConversationUpdated();
        }

        public bool IsActive()
        {
            TriggerExitAction();
            return currentDialogue != null;
        }


        public bool IsChoosing()
        {
            return isChoosing;
        }

        public void Next()
        {
            Debug.Log("HAS NEXT IS " + HasNext());
            if (HasNext() == false)
            {
                isChoosing = false;
                Quit();
                return;
            }
            int numPlayerResponses;
            if (currentDialogue != null)
            {
                numPlayerResponses = currentDialogue.GetPlayerChildren(currentNode).Count();
            }

            else
            {
                numPlayerResponses = 0;
            }

            if (numPlayerResponses > 0)
            {
                isChoosing = true;
                TriggerExitAction();
                onConversationUpdated();
                return;
            }


            DialogueNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            TriggerExitAction();
            currentNode = children[UnityEngine.Random.Range(0, children.Count())];
            TriggerEnterAction();
            onConversationUpdated();




        }

        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }

        public bool HasNext()
        {
            if (currentDialogue != null)
            {
                return (currentDialogue.GetAllChildren(currentNode).Count() > 0);

            }
            else
            {
                return false;
            }
        }

        public void SelectChoice(DialogueNode chosenNode)
        {
            currentNode = chosenNode;
            TriggerEnterAction();
            isChoosing = false;
            Next();
        }

        public string GetText()
        {
            if (currentNode == null)
            {
                return "";
            }
            else
            {
                return currentNode.GetSpeech();
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Quit()
        {
            currentDialogue = null;
            TriggerExitAction();
            currentConversant = null;
            currentNode = null;
            isChoosing = false;
            onConversationUpdated();
        }

        private void TriggerEnterAction()
        {
            if (currentNode != null)
            {
                TriggerAction(currentNode.GetOnEnterAction());
            }

        }

        private void TriggerExitAction()
        {
            if (currentNode != null)
            {
                TriggerAction(currentNode.GetOnExitAction());
            }


        }

        private void TriggerAction(string action)
        {
            if (action == "")
            {
                return;
            }
            else
            {
                // foreach (DialogueTrigger trigger in currentConversant.GetComponentsInChildren<DialogueTrigger>())
                // {
                //     trigger.Trigger(action);
                // }
                currentConversant.GetComponent<DialogueTrigger>().Trigger(action);

            }


        }

        public string GetCurrentConversantName()
        {
            if (isChoosing == true)
            {
                return Name;
            }
            else
            {
                return currentConversant.GetConversantName();
            }
        }

        public Sprite GetCurrentConversantImage()
        {
            if (isChoosing == true)
            {
                return myImage;
            }
            else
            {
                return currentConversant.GetConversantImage();
            }
        }

    }
}
