using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public GameObject thisUI;
    public int toLoad;

    private Loader loader;

    private PlayerController player;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        loader = FindObjectOfType<Loader>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            loader.toLoad = toLoad;
            thisUI.SetActive(true);
            player.doingSomething = true;

            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.doingSomething = false;
        }
    }
}