using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelUI : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseMenuLevelUI()
    {
        this.gameObject.SetActive(false);
    }
    public void ToLevel()
    {
        StartCoroutine(ToPlay());
    }
    IEnumerator ToPlay()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Play");
    }
}
