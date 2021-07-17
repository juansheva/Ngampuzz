using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private PlayerController player;
    private GameObject goUI;
    private Loader loader;
    public Transform target;
    public string position;

    public bool transfer;
    public float waitTransfer;
    private AudioManager audioManager;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        loader = FindObjectOfType<Loader>();
        goUI = GameObject.Find("UI/Go Manager/Go");
        audioManager = FindObjectOfType<AudioManager>();
        waitTransfer = 1;
    }

    private void Update()
    {
        if (transfer)
        {
            waitTransfer -= Time.deltaTime;
        }
        if (waitTransfer <= 0)
        {
            transfer = false;
            player.transform.position = target.position;
            player.lastPosition = position;
            waitTransfer = 1;
            audioManager.Play("Open Door");
        }
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        if (position == player.lastPosition)
        {
            goUI.SetActive(false);
            player.doingSomething = false;
        }
        else
        {
            goUI.SetActive(false);
            transfer = true;
            loader.Loading();
        }
    }
}