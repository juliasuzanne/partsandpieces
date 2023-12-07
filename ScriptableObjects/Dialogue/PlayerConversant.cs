using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{


    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] Dialogue currentDialogue;
        // Start is called before the first frame update
        void Start()
        {
        }



        public string GetText()
        {
            if (currentDialogue == null)
            {
                Debug.Log("Current Dialogue is NULL");
                return "";
            }
            else
            {
                return currentDialogue.GetRootNode().GetSpeech();

            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
