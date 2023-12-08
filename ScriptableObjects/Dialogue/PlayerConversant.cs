using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Dialogue
{


    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] Dialogue currentDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;

        private void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
        }

        public bool IsChoosing()
        {
            return isChoosing;
        }

        public void Next()
        {
            int numPlayerResponses = currentDialogue.GetPlayerChildren(currentNode).Count();
            if (numPlayerResponses > 0)
            {
                isChoosing = true;
                return;
            }
            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            currentNode = children[Random.Range(0, children.Count())];
        }

        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }

        public bool HasNext()
        {
            return (currentDialogue.GetAllChildren(currentNode).Count() > 0);
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
    }
}
