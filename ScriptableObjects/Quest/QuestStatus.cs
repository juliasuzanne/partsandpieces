using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [System.Serializable]

    public class QuestStatus
    {
        [SerializeField] Quest quest;
        [SerializeField] List<string> completedObjectives;

        public Quest GetQuest()
        {
            return quest;
        }

        public int GetCompletedCount()
        {
            return completedObjectives.Count;
        }
    }

}
