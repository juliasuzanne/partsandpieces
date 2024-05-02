using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{

    public class TrainState : MonoBehaviour
    {
        [SerializeField] private CaveSaveSettings _saveSettings;
        [SerializeField] private Dialogue noTicketDialogue;
        [SerializeField] private Dialogue yesTicketDialogue;
        [SerializeField] private AIConversant _conductor;

        void Start()
        {
            if (_saveSettings == null)
            {
                _saveSettings = FindObjectOfType<CaveSaveSettings>();
            }
            Setup();
        }

        void Setup()
        {
            if (_saveSettings.so.hasTicket)
            {
                _conductor.ChangeDialogue(yesTicketDialogue);
            }
            else
            {
                _conductor.ChangeDialogue(noTicketDialogue);
            }
        }
    }
}