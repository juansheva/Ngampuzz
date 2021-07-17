using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public string[] dialogueLines;
    public bool choice;
    public bool quest;
    public bool music;

    public int toLoad;
    Loader loader;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        loader = FindObjectOfType<Loader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            if (!dialogueManager.dialogActive)
            {
                loader.toLoad = toLoad;
                dialogueManager.choice = choice;
                dialogueManager.quest = quest;
                dialogueManager.music = music;
                dialogueManager.dialogLines = dialogueLines;
                dialogueManager.currentLine = 0;
                dialogueManager.ShowDialogue();
            }
        }
    }
}
