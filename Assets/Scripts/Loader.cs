using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public Animator[] loader;
    private PlayerController player;
    private TimeManager timeManager;
    public int toLoad;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Loading()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        player.doingSomething = true;
        timeManager.timePlay = false;
        loader[toLoad].SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        loader[toLoad].SetTrigger("Middle");
        loader[toLoad].ResetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        loader[toLoad].ResetTrigger("Middle");
        player.doingSomething = false;
        timeManager.timePlay = true;
    }
}