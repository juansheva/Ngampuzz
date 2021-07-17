using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    public Animator animSetting;
    public GameObject settingUI;
    public Slider volume;
    public Animator animTutor;
    public GameObject tutorial;

    public GameObject[] Tutor;
    // Start is called before the first frame update
    void Start()
    {
        volume.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volume.value;
    }
    public void OpenSetting()
    {
        settingUI.SetActive(true);
    }
    public void CloseSetting()
    {
        StartCoroutine(CloseAnimSetting());
    }
    IEnumerator CloseAnimSetting()
    {
        animSetting.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1);
        settingUI.SetActive(false);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void OpenTutorial()
    {
        tutorial.SetActive(true);
    }public void CloseTutor()
    {
        StartCoroutine(CloseAnimTutor());
    }
    IEnumerator CloseAnimTutor()
    {
        animTutor.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1);
        tutorial.SetActive(false);
    }
    public void O2()
    {
        Tutor[0].SetActive(true);
    }
    public void O3()
    {
        Tutor[1].SetActive(true);
    }
    public void C2()
    {
        Tutor[0].SetActive(false);
    }
    public void C3()
    {
        Tutor[1].SetActive(false);
    }
}
