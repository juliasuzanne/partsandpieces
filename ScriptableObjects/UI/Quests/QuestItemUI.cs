using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text progress;
    QuestStatus status;

    public void Setup(QuestStatus status)
    {
        this.status = status;
        title.text = status.GetQuest().GetTitle();
        progress.text = status.GetCompletedCount() + "/" + status.GetQuest().GetObjectiveCount();
    }

    public QuestStatus GetQuestStatus()
    {
        return status;
    }
}
