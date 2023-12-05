using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueNode : ScriptableObject
    {
        public string speech;
        public List<string> children = new List<string>();
        public Rect rect = new Rect(0, 0, 200, 100);
    }

}
