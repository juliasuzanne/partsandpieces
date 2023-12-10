using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;
using UnityEngine.UI;

namespace Quests
{
    public class QuestTooltipUI : MonoBehaviour
    {
        [SerializeField] Text title;
        [SerializeField] Transform objectiveContainer;
        [SerializeField] GameObject objectivePrefab;
        // Start is called before the first frame update
        public void Setup(Quest quest)
        {
            title.text = quest.GetTitle();
            objectiveContainer.DetachChildren();
            foreach (string objective in quest.GetObjectives())
            {
                GameObject objectiveInstance = Instantiate(objectivePrefab, objectiveContainer);
                Text objectiveText = objectiveInstance.GetComponentInChildren<Text>();
                objectiveText.text = objective;
            }
        }


    }


}
