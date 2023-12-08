using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialogue;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class DialogueUI : MonoBehaviour
    {
        PlayerConversant playerConversant;
        [SerializeField] TextMeshProUGUI AIText;
        [SerializeField] Button nextButton;
        [SerializeField] Transform choiceRoot;
        [SerializeField] GameObject choicePrefab;
        // Start is called before the first frame update
        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            nextButton.onClick.AddListener(Next);
            UpdateUI();
        }

        void Next()
        {
            playerConversant.Next();
            UpdateUI();

        }
        void UpdateUI()
        {
            AIText.text = playerConversant.GetText();
            nextButton.gameObject.SetActive(playerConversant.HasNext());
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }
            foreach (string choiceText in playerConversant.GetChoices())
            {
                GameObject currentChoicePrefab = Instantiate(choicePrefab, choiceRoot);
                currentChoicePrefab.GetComponentInChildren<Text>().text = choiceText;

            }
        }

    }
}
