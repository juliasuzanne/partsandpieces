using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string task in quest.GetTask())
        {
            Debug.Log($"Has task {task}");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
