using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private GameObject questUI;
    private PlayerController player;

    public List<Quest> quest = new List<Quest>();
    public bool[] questCompleted;
    public bool[] hasInstantiate;
    private bool[] hasScoring;
    public bool[] questFailed;
    public bool mainQuest;
    public bool hasLate;
    public bool loading;

    public Text[] questText;

    public int questNumber;

    public bool fixedTimeSkip;
    public int timeSkipMinutes;
    public int timeSkipHours;
    private TimeManager timeManager;
    private ScoreManager scoreManager;
    private ResultManager resultManager;

    private QuestGiver questGiver;

    // Start is called before the first frame update

    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        timeManager = FindObjectOfType<TimeManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        resultManager = FindObjectOfType<ResultManager>();
        player = FindObjectOfType<PlayerController>();
        questUI = GameObject.Find("UI/Quest Manager/Quest UI");

        if (questGiver != null)
        {
            quest = questGiver.quest;
        }
        loading = true;
        questCompleted = new bool[quest.Count];
        questFailed = new bool[quest.Count];
        hasInstantiate = new bool[quest.Count];
        hasScoring = new bool[quest.Count];
        Time.timeScale = 0;
        player.doingSomething = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeManager.hours >= 6 && timeManager.minutes >= 30 || timeManager.hours > 6 && timeManager.minutes >= 0)
        {
            loading = false;
        }
        if (timeManager.hours >= resultManager.resultTime)
        {
            loading = true;
        }
        Scoring();
        //quest = questGiver.quest;
        if (quest != null)
        {
            for (int index = 0; index < quest.Count; index++)
            {
                if (!resultManager.result && !loading)
                {
                    if (!hasInstantiate[index])
                    {
                        if (timeManager.hours == quest[index].startQuestHours)
                        {
                            if (timeManager.minutes >= quest[index].startQuestMinutes)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    Instantiate(quest[index].interact);
                                    hasInstantiate[index] = true;
                                }
                            }
                        }
                        if (timeManager.hours > quest[index].startQuestHours)
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                Instantiate(quest[index].interact);
                                hasInstantiate[index] = true;
                            }
                        }
                    }
                }
            }
        }

        for (int index = 0; index < quest.Count; index++)
        {
            if (questText[index] != null)
            {
                questText[index].text = quest[index].quest;
            }
        }
    }

    public void QuestCompleted()
    {
        questCompleted[questNumber] = true;
        if (fixedTimeSkip == true)
        {
            timeManager.hours = timeSkipHours;
            timeManager.minutes = timeSkipMinutes;
            fixedTimeSkip = false;
        }
        else
        {
            timeManager.hours += timeSkipHours;
            timeManager.minutes += timeSkipMinutes;
        }
    }

    public void Close()
    {
        questUI.SetActive(false);
        player.doingSomething = false;

        Time.timeScale = 1;
    }

    public void Scoring()
    {
        for (int i = 0; i < quest.Count; i++)
        {
            if (!resultManager.result && !loading)
            {
                if (questCompleted[i] && !hasScoring[i])
                {
                    if (quest[i].mainQuest)
                    {
                        if (hasLate)
                        {
                            scoreManager.score += 500;
                        }
                        else
                        {
                            scoreManager.score += 1000;
                        }
                    }
                    if (!quest[i].mainQuest)
                    {
                        scoreManager.score += 500;
                    }
                    hasScoring[i] = true;
                }
            }
        }
    }
}