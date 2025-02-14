using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeleportationPanel : MonoBehaviour
{
    public GameObject Player;
    public GameObject panel;
    public Transform  homeTeleportPanel;
    public TMP_Text text_;
    void Start()
    {
        closePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPanel(string txt=""){

        text_.text = txt;
        openPanel();
        StartCoroutine(ExampleCoroutine(7));
    }


    private void openPanel(){
        
        panel.SetActive(true);
    }

    public void closePanel(){
        
        panel.SetActive(false);
    }

    public void teleportation(){
        closePanel();
        Player.transform.position = homeTeleportPanel.position;
    }


    IEnumerator ExampleCoroutine(int time)
    {

        openPanel();
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        closePanel();
    }
}

