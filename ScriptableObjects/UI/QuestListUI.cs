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
        foreach (Quest quest in tempQuest)
        {
            foreach (string task in quest.GetTask())
            {
                Debug.Log($"Has task {task}");

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
