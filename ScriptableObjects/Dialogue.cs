using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue Object", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [SerializeField]
        DialogueNode[] nodes;

    }
}
