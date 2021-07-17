using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    QuestManager questManager;
    public Quest quest;
    TimeManager timeManager;
    public GameObject npc;

    public bool hasLate;

    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.hours >= quest.lateQuestHours)
        {
            if (timeManager.minutes >= quest.lateQuestMinutes)
            {
                hasLate = true;
            }
        }
        if (quest.endQuestHours <= timeManager.hours)
        {
            if (quest.endQuestMinutes < timeManager.minutes)
            {
                questManager.questFailed[quest.questNumber] = true;
                DestroyNPC();
                Destroy();
            }
            if (quest.endQuestMinutes > timeManager.minutes)
            {
                if (quest.endQuestHours+1 <= timeManager.hours)
                {
                    questManager.questFailed[quest.questNumber] = true;
                    DestroyNPC();
                    Destroy();
                }
            }
        }
        if (questManager.questCompleted[quest.questNumber])
        {
            DestroyNPC();
            Destroy();
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            questManager.hasLate = hasLate;
            questManager.mainQuest = quest.mainQuest;
            questManager.questNumber = quest.questNumber;
            questManager.fixedTimeSkip = quest.fixedTimeSkip;
            questManager.timeSkipHours = quest.timeSkipHours;
            questManager.timeSkipMinutes = quest.timeSkipMinutes;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            questManager.hasLate = false;

        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    public void DestroyNPC()
    {
        if (npc != null)
        {
            Destroy(npc.gameObject);
        }
    }
}
