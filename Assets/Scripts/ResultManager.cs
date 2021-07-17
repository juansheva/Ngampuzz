using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    private GameObject resultUI;
    private TimeManager timeManager;
    private PlayerController player;

    private QuestGiver questGiver;
    public int resultTime;
    public GameObject[] next;
    public bool result;

    // Start is called before the first frame update
    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        resultUI = GameObject.Find("/UI/Result Manager/Result");
        timeManager = FindObjectOfType<TimeManager>();
        player = FindObjectOfType<PlayerController>();
        if (questGiver != null)
        {
            resultTime = questGiver.resultTime;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeManager.hours >= resultTime)
        {
            result = true;
            resultUI.SetActive(true);
            Time.timeScale = 0;
            player.doingSomething = true;

            for (int i = 0; i < next.Length; i++)
            {
                if (questGiver)
                {
                    if (i == questGiver.level)
                    {
                        next[i - 1].SetActive(true);
                    }
                }
            }
        }
    }

    public void Menu()
    {
        timeManager.hours = 7;
        resultUI.SetActive(false);
        Time.timeScale = 1;
        player.doingSomething = false;

        SceneManager.LoadScene("Menu");
    }
}