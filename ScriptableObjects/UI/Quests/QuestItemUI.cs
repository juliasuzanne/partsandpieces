using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text progress;
    Quest quest;

    public void Setup(Quest quest)
    {
        title.text = quest.GetTitle();
        progress.text = "0/" + quest.GetObjectiveCount();
        this.quest = quest;
    }

    public Quest GetQuest()
    {
        return quest;
    }
}
