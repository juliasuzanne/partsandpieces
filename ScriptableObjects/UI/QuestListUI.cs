using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class QuestListUI : MonoBehaviour
{
    [SerializeField] Quest[] tempQuest;
    [SerializeField] QuestItemUI questPrefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();
        foreach (Quest quest in tempQuest)
        {
            QuestItemUI uiInstance = Instantiate<QuestItemUI>(questPrefab, transform);
            uiInstance.Setup(quest);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
