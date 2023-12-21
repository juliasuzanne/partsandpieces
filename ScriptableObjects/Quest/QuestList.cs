using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Quests
{
    public class QuestList : MonoBehaviour
    {
        List<QuestStatus> statuses = new List<QuestStatus>();
        public event Action onQuestsUpdated;


        public IEnumerable<QuestStatus> GetStatuses()
        {
            return statuses;
        }

        public bool HasQuest(Quest quest)
        {
            return GetQuestStatus(quest) != null;
        }
        public void AddQuest(Quest quest)
        {
            if (HasQuest(quest))
            {
                return;
            }
            QuestStatus newStatus = new QuestStatus(quest);
            statuses.Add(newStatus);
            if (onQuestsUpdated != null)
            {

                onQuestsUpdated();

            }
        }

        public void CompleteObjective(Quest quest, string objective)
        {
            Debug.Log("Complete quest");
            QuestStatus status = GetQuestStatus(quest);
            status.CompleteObjective(objective);
            if (onQuestsUpdated != null)
            {

                onQuestsUpdated();

            }

        }

        private QuestStatus GetQuestStatus(Quest quest)
        {
            foreach (QuestStatus status in statuses)
            {
                if (status.GetQuest() == quest)
                {
                    return status;
                }

            }
            return null;
        }


    }
}

