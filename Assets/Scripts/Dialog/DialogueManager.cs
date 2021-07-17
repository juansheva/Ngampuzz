using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private GameObject dialogUI;
    private GameObject dialog;
    public Text dialogText;
    private GameObject choiceUI;
    private GameObject musicUI;
    private QuestManager questManager;
    private ScoreManager scoreManager;
    private AudioManager audioManager;
    private Loader loader;

    public bool dialogActive;
    public string[] dialogLines;
    public int currentLine;
    public bool choice;
    public bool quest;
    public bool music;
    public string onMusic;
    public bool mustReset;

    // Start is called before the first frame update
    private void Start()
    {
        dialogUI = GameObject.Find("/UI/Dialog Manager/Dialog UI");
        dialog = GameObject.Find("/UI/Dialog Manager/Dialog UI/Dialog");
        choiceUI = GameObject.Find("/UI/Dialog Manager/Dialog UI/Choice");
        musicUI = GameObject.Find("/UI/Dialog Manager/Dialog UI/Music");
        audioManager = FindObjectOfType<AudioManager>();
        loader = FindObjectOfType<Loader>();
        scoreManager = FindObjectOfType<ScoreManager>();
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentLine >= dialogLines.Length)
        {
            dialog.SetActive(false);
            currentLine = 0;
            if (choice)
            {
                choiceUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                dialogUI.SetActive(false);
                dialogActive = false;
            }
        }

        dialogText.text = dialogLines[currentLine];
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dialogUI.SetActive(true);
        dialog.SetActive(true);
        Time.timeScale = 0;
    }

    public void Next()
    {
        currentLine++;
    }

    public void Ya()
    {
        Tidak();
        dialogUI.SetActive(true);

        if (quest)
        {
            dialogUI.SetActive(false);
            questManager.QuestCompleted();
            loader.Loading();
        }
        if (music)
        {
            dialogActive = true;
            Time.timeScale = 0;
            musicUI.SetActive(true);
        }
    }

    public void Tidak()
    {
        choiceUI.SetActive(false);
        Time.timeScale = 1;
        dialogUI.SetActive(false);
        dialogActive = false;
    }

    public void Channel1()
    {
        Time.timeScale = 1;
        dialogActive = false;
        dialogUI.SetActive(false);
        musicUI.SetActive(false);
        audioManager.Stop(onMusic);
        onMusic = "Channel 1";
        audioManager.Play(onMusic);
        mustReset = true;
    }

    public void Channel2()
    {
        Time.timeScale = 1;
        dialogActive = false;
        dialogUI.SetActive(false);
        musicUI.SetActive(false);
        audioManager.Stop(onMusic);
        onMusic = "Channel 2";
        audioManager.Play(onMusic);
        mustReset = true;
    }
}