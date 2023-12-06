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
        Vector2 scrollPosition;
        [System.NonSerialized]
        Vector2 draggingOffset;
        [System.NonSerialized]
        GUIStyle nodeStyle;
        [System.NonSerialized]
        DialogueNode draggingNode = null;
        [System.NonSerialized]
        DialogueNode creatingNode = null;
        [System.NonSerialized]
        DialogueNode deletingNode = null;
        [System.NonSerialized]
        DialogueNode linkingNode = null;
        [System.NonSerialized]
        bool draggingCanvas = false;
        [System.NonSerialized]
        Vector2 draggingCanvasOffset;

        const float canvasSize = 4000;
        const float backgroundSize = 50;


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

                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

                Rect canvas = GUILayoutUtility.GetRect(canvasSize, canvasSize);

                Texture2D backgroundTex = Resources.Load("background") as Texture2D;

                Rect texCoords = new Rect(0, 0, canvasSize / backgroundSize, canvasSize / backgroundSize);

                GUI.DrawTextureWithTexCoords(canvas, backgroundTex, texCoords);

                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                    DrawConnections(node);

                }
                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                    DrawNode(node);

                }

                EditorGUILayout.EndScrollView();

                if (creatingNode != null)
                {
                    selectedDialogue.CreateNode(creatingNode);
                    creatingNode = null;
                }
                if (deletingNode != null)
                {
                    selectedDialogue.DeleteNode(deletingNode);
                    deletingNode = null;
                }


            }


        }

        private void ProcessEvents()
        {
            if (Event.current.type == EventType.MouseDown && draggingNode == null)
            {
                draggingNode = GetNodeAtPoint(Event.current.mousePosition + scrollPosition);
                if (draggingNode != null)
                {
                    draggingOffset = draggingNode.GetRect().position - Event.current.mousePosition;
                    Selection.activeObject = draggingNode;
                }
                else
                {
                    Selection.activeObject = selectedDialogue;

                }

            }
            else if (Event.current.type == EventType.MouseDrag && draggingNode != null)
            {
                draggingNode.SetPosition(Event.current.mousePosition + draggingOffset);
                GUI.changed = true;

            }
            else if (Event.current.type == EventType.MouseUp && draggingCanvas)
            {
                GUI.changed = true;
            }

            else if (Event.current.type == EventType.MouseUp && draggingNode != null)
            {
                draggingNode = null;
            }

        }

        private DialogueNode GetNodeAtPoint(Vector2 point)
        {
            DialogueNode foundNode = null;
            foreach (DialogueNode node in selectedDialogue.GetAllNodes())
            {
                if (node.GetRect().Contains(point))
                {
                    foundNode = node;
                }

            }
            return foundNode;
        }

        private void DrawNode(DialogueNode node)
        {

            GUILayout.BeginArea(node.GetRect(), nodeStyle);
            node.SetSpeech(EditorGUILayout.TextField(node.GetSpeech()));

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("+"))
            {
                creatingNode = node;
            }

            DrawLinkButtons(node);

            if (GUILayout.Button("-"))
            {
                deletingNode = node;
            }
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        private void DrawLinkButtons(DialogueNode node)
        {
            if (linkingNode == null)
            {
                if (GUILayout.Button("link"))
                {
                    linkingNode = node;
                }

            }
            else
            {
                Undo.RecordObject(selectedDialogue, "Add Dialogue Link");
                if (linkingNode == node)
                {
                    if (GUILayout.Button("cancel"))
                    {
                        linkingNode = null;

                    }
                }
                else if (linkingNode.GetChildren().Contains(node.name))
                {
                    if (GUILayout.Button("remove child"))
                    {
                        linkingNode.RemoveChild(node.name);
                        linkingNode = null;

                    }
                }
                else
                {
                    if (GUILayout.Button("add child"))
                    {
                        linkingNode.AddChild(node.name);
                        linkingNode = null;

                    }

                }
            }
        }

        private void DrawConnections(DialogueNode node)
        {
            Vector2 startPosition = new Vector2(node.GetRect().xMax, node.GetRect().center.y);


            foreach (DialogueNode childNode in selectedDialogue.GetAllChildren(node))
            {
                Vector2 endPosition = new Vector2(childNode.GetRect().xMin, childNode.GetRect().center.y);
                Vector2 controlPointOffset = endPosition - startPosition;
                controlPointOffset.y = 0;
                controlPointOffset.x *= 0.8f;

                Handles.DrawBezier(startPosition, endPosition,
                startPosition + controlPointOffset,
                endPosition - controlPointOffset,
                Color.white, null, 4f);
            }
        }
    }
}

