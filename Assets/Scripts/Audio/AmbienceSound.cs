using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            audioManager.Play("Ambience");
        }

    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            audioManager.Stop("Ambience");
        }
    }

}
