using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
    public class Quest : ScriptableObject
    {
        [SerializeField] List<string> objectives;
        public string GetTitle()
        {
            return name;
        }
        public int GetObjectiveCount()
        {
            return objectives.Count;
        }

        public IEnumerable<string> GetObjective()
        {
            yield return "Task 1";
            yield return "Task 2";
        }
    }
}
