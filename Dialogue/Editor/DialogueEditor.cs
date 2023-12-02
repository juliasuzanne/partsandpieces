using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Callbacks;

namespace Dialogue.Editor
{

    public class DialogueEditor : EditorWindow
    {
        Dialogue selectedDialogue = null;
        GUIStyle nodeStyle;
        DialogueNode draggingNode = null;

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
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("node0") as Texture2D;
            nodeStyle.padding = new RectOffset(20, 20, 20, 20);
            nodeStyle.border = new RectOffset(12, 12, 12, 12);
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
                ProcessEvents();
                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                    OnGUINode(node);
                }

            }


        }

        private void ProcessEvents()
        {
            if (Event.current.type == EventType.MouseDown && draggingNode == null)
            {
                draggingNode = GetNodeAtPoint(Event.current.mousePosition);
            }
            else if (Event.current.type == EventType.MouseDrag && draggingNode != null)
            {
                Undo.RecordObject(selectedDialogue, "Update Node Pos");
                draggingNode.rect.position = Event.current.mousePosition;
                GUI.changed = true;

            }
            else if (Event.current.type == EventType.MouseUp && draggingNode != null)
            {
                draggingNode = null;
            }
        }

        private DialogueNode GetNodeAtPoint(Vector2 point)
        {
            foreach (DialogueNode node in selectedDialogue.GetAllNodes())
            {
                if (node.rect.Contains(point))
                {
                    return node;
                }
            }
            return null;
        }

        private void OnGUINode(DialogueNode node)
        {

            GUILayout.BeginArea(node.rect, nodeStyle);
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Node: ");
            string newText = EditorGUILayout.TextField(node.speech);
            string newID = EditorGUILayout.TextField(node.uniqueID);


            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(selectedDialogue, "Update Dialogue Text");
                node.uniqueID = newID;
                node.speech = newText;

            }

            GUILayout.EndArea();
        }
    }
}

