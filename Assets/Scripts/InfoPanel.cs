using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text_;
    void Start()
    {
        hiddenInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInformation(string text, int time=3){

        Debug.Log("clicked Information");
        
        StartCoroutine(ExampleCoroutine(text, time));
    }

    private void showInfo(string text){
        
        panel.SetActive(true);
        text_.text = text;
    }

    private void hiddenInfo(){
        
        panel.SetActive(false);
    }


    IEnumerator ExampleCoroutine(string text, int time)
    {

        showInfo(text);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        hiddenInfo();
    }
}
