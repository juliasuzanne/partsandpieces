using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
using GameDevTV.Core.UI.Tooltips;

namespace Quests
{
    public class QuestToolTipSpawner : TooltipSpawner
    {
        public override bool CanCreateTooltip()
        {
            return true;
        }

        public override void UpdateTooltip(GameObject tooltip)
        {
            Quest quest = GetComponent<QuestItemUI>().GetQuest();
            tooltip.GetComponent<QuestTooltipUI>().Setup(quest);
        }

    }

}
