using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private PlayerController player;
    public GameObject pauseUI;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        player.doingSomething = true;

        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        player.doingSomething = false;

        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}