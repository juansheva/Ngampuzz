using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Image icon;
    public Sprite[] nilai;
    public int maxScore;
    public QuestGiver questGiver;


    // Start is called before the first frame update
    void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        maxScore = questGiver.maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == maxScore)
        {
            icon.sprite = nilai[0];
        }
        if (score >= (maxScore - 1000)&&score<maxScore)
        {
            icon.sprite = nilai[1];
        }
        if (score >= (maxScore - 2000)&&score<(maxScore-1000))
        {
            icon.sprite = nilai[2];

        }
        if (score < (maxScore - 2000))
        {
            icon.sprite = nilai[3];

        }
        Debug.Log(score);

    }
}
