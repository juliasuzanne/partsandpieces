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

        private void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
        }

        public void Next()
        {
            DialogueNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            currentNode = children[Random.Range(0, children.Count())];
        }

        public IEnumerable<string> GetChoices()
        {
            yield return "I've lived here all my life!";
            yield return "I came here from Newton";
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
