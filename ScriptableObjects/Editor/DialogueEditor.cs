using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dialogue.Editor
{

    public class DialogueEditor : EditorWindow
    {
        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            Debug.Log("ShowEditorWindow");
        }
    }

}