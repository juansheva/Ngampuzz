using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteract : MonoBehaviour
{
    private GameObject questUI;
    private PlayerController player;
    private GameObject computerChoice;
    private GameObject musicChoice;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        questUI = GameObject.Find("UI/Quest Manager/Quest UI");
        computerChoice = GameObject.Find("UI/Computer/Computer Choice");
        musicChoice = GameObject.Find("UI/Music Manager/Music Choice");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            Time.timeScale = 0;
            computerChoice.SetActive(true);
            player.doingSomething = true;
        }
    }

    public void LihatQuest()
    {
        computerChoice.SetActive(false);
        questUI.SetActive(true);
    }

    public void MainkanMusic()
    {
        computerChoice.SetActive(false);
        musicChoice.SetActive(true);
    }
}