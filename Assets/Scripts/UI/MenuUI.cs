using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuLevelUI;
    public GameObject logo;
    public Animator logoAnim;
    QuestGiver questGiver;
    // Start is called before the first frame update
    void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!questGiver.notPlay)
        {
            logo.SetActive(false);
        }
    }
    public void OpenMenuLevelUI()
    {
        menuLevelUI.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void CloseLogo()
    {
        StartCoroutine(ClosingLogo());
    }
    IEnumerator ClosingLogo()
    {
        logoAnim.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1);
        logo.SetActive(false);
    }
}
