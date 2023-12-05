using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class DialogueNode
    {
        public string uniqueID;
        public string speech;
        public List<string> children = new List<string>();
        public Rect rect = new Rect(0, 0, 200, 100);
    }

}
