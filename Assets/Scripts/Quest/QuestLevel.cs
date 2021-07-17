using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestLevel : MonoBehaviour
{
    public List<Quest> quest = new List<Quest>();
    public NPCList npcList;
    QuestGiver questGiver;
    public int resultTime;
    public int level;
    Loader loader;
    public int maxScore;
    public bool notPlay;

    // Start is called before the first frame update
    void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        loader = FindObjectOfType<Loader>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TransferQuest()
    {
        questGiver.notPlay = notPlay;
        questGiver.maxScore = maxScore;
        questGiver.npcList = npcList;
        questGiver.resultTime = resultTime;
        questGiver.level = level;
        questGiver.quest = quest;
    }
    public void NextLevel()
    {
        StartCoroutine(LoadNew());
    }
    IEnumerator LoadNew()
    {
        loader.loader[0].SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        loader.loader[0].SetTrigger("Middle");
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
