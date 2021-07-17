using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSound : MonoBehaviour
{
    AudioManager audioManager;
    DialogueManager dialogueManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            if (dialogueManager.mustReset)
            {
                audioManager.Stop(dialogueManager.onMusic);
                dialogueManager.onMusic = "Ingame";
                audioManager.Play(dialogueManager.onMusic);
                dialogueManager.mustReset = false;
            }
        }
    }
}
