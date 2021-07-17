using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest")]
public class Quest : ScriptableObject
{
    public string questName = "New Quest";
    public string quest = null;
    public bool mainQuest;
    public bool fixedTimeSkip;
    public int questNumber;
    public int startQuestHours;
    public int startQuestMinutes;
    public int lateQuestHours;
    public int lateQuestMinutes;
    public int endQuestHours;
    public int endQuestMinutes;
    public int timeSkipHours;
    public int timeSkipMinutes;
    public GameObject interact;
}
