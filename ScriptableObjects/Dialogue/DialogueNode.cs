using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueNode : ScriptableObject
    {
        [SerializeField]
        private string speech;
        [SerializeField]
        private List<string> children = new List<string>();
        [SerializeField]
        private Rect rect = new Rect(0, 0, 200, 100);

        public Rect GetRect()
        {
            return rect;
        }

        public string GetSpeech()
        {
            return speech;
        }

        public List<string> GetChildren()
        {
            return children;
        }
#if UNITY_EDITOR
        public void SetPosition(Vector2 newPos)
        {
            Undo.RecordObject(this, "Update Node Pos");
            rect.position = newPos;
        }
        public void SetText(string newSpeech)
        {
            if (newSpeech != speech)
            {
                Undo.RecordObject(this, "Update Dialogue Text");
                speech = newSpeech;
            }
        }

        public void AddChild(string childID)
        {
            Undo.RecordObject(this, "Add link");
            children.Add(childID);
        }

          public void RemoveChild(string childID)
        {
            Undo.RecordObject(this, "Remove link");
            children.Remove(childID);
        }

#endif
    }

}
