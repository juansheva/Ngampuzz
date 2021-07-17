using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public string scene;
    private DialogueManager dialogueManager;
    private AudioManager audioManager;
    private GameObject musicChoice;
    private PlayerController player;

    private ResetSound resetSound;

    // Start is called before the first frame update
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        audioManager = FindObjectOfType<AudioManager>();
        musicChoice = GameObject.Find("UI/Music Manager/Music Choice");
        player = FindObjectOfType<PlayerController>();

        if (scene == "Ingame")
        {
            audioManager.Play("Ingame");
            dialogueManager.onMusic = "Ingame";
        }
        else
        {
            audioManager.Play("Main Menu");
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Track1()
    {
        Time.timeScale = 1;
        musicChoice.SetActive(false);
        audioManager.Stop(dialogueManager.onMusic);
        dialogueManager.onMusic = "Track 1";
        audioManager.Play(dialogueManager.onMusic);
        player.doingSomething = false;
        dialogueManager.mustReset = true;
    }

    public void Track2()
    {
        Time.timeScale = 1;
        musicChoice.SetActive(false);
        audioManager.Stop(dialogueManager.onMusic);
        dialogueManager.onMusic = "Track 2";
        audioManager.Play(dialogueManager.onMusic);
        player.doingSomething = false;
        dialogueManager.mustReset = true;
    }
}