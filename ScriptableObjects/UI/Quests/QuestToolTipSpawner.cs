using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Core.UI.Tooltips;

public class QuestToolTipSpawner : TooltipSpawner
{
    public override bool CanCreateTooltip()
    {
        return true;
    }

    public override void UpdateTooltip(GameObject tooltip)
    {

    }

}
