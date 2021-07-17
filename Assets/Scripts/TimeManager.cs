using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private float timeCounter;
    public int hours;
    public int minutes;
    public bool timePlay;

    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timePlay)
        {

            timeCounter += Time.deltaTime;
            if (timeCounter >= 5)
            {
                timeCounter = 0;
                minutes += 15;
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours++;

                }
            }
            if (hours < 10 && minutes < 10)
            {
                timeText.text = "0" + hours + ".0" + minutes;
            }
            if (hours < 10 && minutes >= 10)
            {
                timeText.text = "0" + hours + "." + minutes;
            }
            if (hours >= 10 && minutes < 10)
            {
                timeText.text = hours + ".0" + minutes;
            }
            if (hours >= 10 && minutes > 10)
            {
                timeText.text = hours + "." + minutes;
            }
        }
    }
}
