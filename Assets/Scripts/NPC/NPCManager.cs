using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCManager : MonoBehaviour
{
    public NPCList npcList;
    QuestGiver questGiver;
    // Start is called before the first frame update
    void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        if (questGiver)
        {
            npcList = questGiver.npcList;
        }
        for (int i = 0; i < npcList.npcList.Length; i++)
        {
            Instantiate(npcList.npcList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
