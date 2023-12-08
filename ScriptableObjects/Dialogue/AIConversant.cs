using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue = null;
        private PlayerConversant playerConversant;

        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }
        private void OnMouseDown()
        {
            if (dialogue == null)
            {
            }
            else
            {
                playerConversant.StartDialogue(this, dialogue);
            }

        }


    }
}

