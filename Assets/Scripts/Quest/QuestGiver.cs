using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public static QuestGiver instance { get; private set; }
    public List<Quest> quest = new List<Quest>();
    public NPCList npcList;
    public int maxScore;
    public int resultTime;
    private bool questGiverExist;
    public int level;
    public bool notPlay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}