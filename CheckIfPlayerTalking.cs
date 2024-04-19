using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Dialogue
{


    public class CheckIfPlayerTalking : MonoBehaviour
    {
        [SerializeField] private PlayerConversant playerConversant;
        // Start is called before the first frame update
        [SerializeField] UnityEvent onPlayerChoosing;
        [SerializeField] UnityEvent onPlayerListening;




        void Start()
        {
            playerConversant.onConversationUpdated += UpdateAnim;
        }

        void UpdateAnim()
        {
            if (playerConversant.IsChoosing())
            {
                onPlayerChoosing.Invoke();
                Debug.Log("PLAYER CHOOSING");
            }
            else if (playerConversant.IsChoosing() == false && playerConversant.IsActive() == true)
            {
                onPlayerListening.Invoke();
                Debug.Log("PLAYER LISTENING");
            }
            else
            {
                // onPlayerChoosing.Invoke();
            }
        }
    }
}