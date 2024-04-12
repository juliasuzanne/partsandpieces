using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Dialogue
{
    public class ATroubleshootingDialogue : MonoBehaviour
    {
        [SerializeField] private Text dialoguetext;
        [SerializeField] private Text hasNext;
        [SerializeField] private Text debugText;
        [SerializeField] private PlayerConversant playerCon;
        // Start is called before the first frame update
        void Start()
        {



        }

        // Update is called once per frame
        void Update()
        {
            hasNext.text = "Next: " + playerCon.HasAnother();
            dialoguetext.text = "Dialogue: " + playerCon.CurrentDialogue();
            debugText.text = "Debug Message: " + playerCon.GetDebugMessage();

        }
    }
}

