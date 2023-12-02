using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Callbacks;

namespace Dialogue.Editor
{

    public class DialogueEditor : EditorWindow
    {
        Dialogue selectedDialogue = null;

        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), false, "Dialogue Editor");
        }
        [OnOpenAssetAttribute(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            Dialogue selectedDialogue = Selection.activeObject as Dialogue;
            if (selectedDialogue != null)
            {
                ShowEditorWindow();
                return true;
            }
            return false;

        }

        private void OnEnable()
        {
            //selection changed event is a list of functions that something in unity will call this list of functions when this selection changes. Add a function to that list of things. 
            //allows us to have a nonstatic function

            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            Dialogue newDialogue = Selection.activeObject as Dialogue;
            if (newDialogue != null)
            {
                selectedDialogue = newDialogue;
                Repaint();
            }
            else
            {
                Debug.Log("Not a dialogue");
            }
            Debug.Log("On selection changed");
        }

        private void OnGUI()
        {
            if (selectedDialogue == null)
            {
                EditorGUILayout.LabelField("No Dialogue Selected");

            }
            else
            {
                EditorGUILayout.LabelField(selectedDialogue.name);
            }
            EditorGUILayout.LabelField("Hello World");

        }
    }
}

