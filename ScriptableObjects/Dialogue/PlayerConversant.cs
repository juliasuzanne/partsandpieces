using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using System.Linq;
using System;

namespace Dialogue
{


    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] Dialogue currentDialogue;
        private string debugMessage;
        [SerializeField] AIConversant currentConversant = null;
        [SerializeField] private Sprite myImage;
        [SerializeField] Dialogue testDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;
        bool changedMoveable;
        [SerializeField] private UnityEvent quitTrigger;
        private string Name;
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
        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void StartDialogue(AIConversant newConversant, Dialogue newDialogue)
        {
            Debug.Log("NEW" + newConversant + "DIALOGUE" + newDialogue);
            currentConversant = newConversant;
            Name = "you";
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            TriggerEnterAction();
            onConversationUpdated();
            if (playerMovement != null)
            {
                if (playerMovement.GetMoveable() == true && currentConversant.FreezeOnTalk() == true)
                {
                    changedMoveable = true;
                    playerMovement.MoveableFalse();
                }
            }

        }

        public void MakeChangedMoveableFalse()
        {
            changedMoveable = false;

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

        public string CurrentDialogue()
        {
            if (currentDialogue != null)
            {
                return currentDialogue.ToString();

            }
            else
            {
                return "null";
            }
        }

        public string HasAnother()
        {
            return HasNext().ToString();
        }

        public string GetDebugMessage()
        {
            return debugMessage;
        }


        public void Next()
        {
            Debug.Log("HAS NEXT IS " + HasNext());
            if (HasNext() == false)
            {
                isChoosing = false;
                debugMessage = "has next is false, quitting";
                Quit();
                return;
            }
            int numPlayerResponses;
            if (currentDialogue != null)
            {
                debugMessage = "getting num player responses, " + currentDialogue.GetPlayerChildren(currentNode).Count().ToString();

                numPlayerResponses = currentDialogue.GetPlayerChildren(currentNode).Count();
            }

            else
            {
                debugMessage = "setting num player responses to zero";
                numPlayerResponses = 0;
            }

            if (numPlayerResponses > 0)
            {
                debugMessage = "player responses good, setting is choosing, trigger exit, update conversation";

                isChoosing = true;
                TriggerExitAction();
                onConversationUpdated();
                return;
            }


            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
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
                debugMessage = "current dialogue not null, returning get all children, current Node is " + currentNode.ToString() + "count of children of current node is " + currentDialogue.GetAllChildren(currentNode).Count().ToString();


                return (currentDialogue.GetAllChildren(currentNode).Count() > 0);

            }
            else
            {
                debugMessage = "current dialogue null, returning false has next";
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
            if (changedMoveable = true)
            {
                playerMovement.MoveableTrue();
            }
            quitTrigger.Invoke();
            Debug.Log("Quit");
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