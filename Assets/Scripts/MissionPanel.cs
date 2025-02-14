using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    public GameObject SCENARIO;
    public TMP_Text button;
    public Image pane; // Assign the Pane UI element in the Inspector
    public TMP_Text titleTxt;
    public TMP_Text statusTxt;
    public TMP_Text descriptionTxt;
    public int missionStatus = 0;       // 0-not active, 1-activated, 2-while during, 3-endGame ...
    void Start()
    {
            RenderSettings.ambientLight = Color.white; // Adjust as needed

        setDescription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStatus(int status){

        if(status==0){
            statusTxt.text = "STATUS: Mission not Activated yet.";
            statusTxt.color = Color.red;
        }
        else if(status==1){
            statusTxt.text = "STATUS: Mission completed";
            statusTxt.color = Color.green;
        }
        else if(status==2){
            statusTxt.text = "STATUS: Mission activated";
            statusTxt.color = Color.yellow;
        }
        else if(status==3){
            statusTxt.text = "Time to go home.";
            statusTxt.color = Color.green;
            button.text = "Go HOME";
            missionStatus = 3;
        }
        
    }


    public void setDescription(string tmp = ""){

        if(tmp==""){
            setStatus(0);
            string txt = SCENARIO.GetComponent<ShowScenarioPanel>().getLevelDescription();
            descriptionTxt.text = txt;
        }else{
            descriptionTxt.text = tmp;
        }

        
    }


    public void setTitle(string tmp = ""){

        if(tmp!=""){
            titleTxt.text = tmp;
        }     
    }


    public void showInfoToQuit(string tmp = ""){

        if(tmp!=""){
            titleTxt.text = tmp;
        }     
    }

    

    public void SetBackgroundColor(Color color)
    {
        if (pane != null)
        {
            pane.color = color;
        }
    }
        


    // public void setBackgroundColor(string tmp = ""){

    //     if(tmp==""){
    //         setStatus(0);
    //         string txt = SCENARIO.GetComponent<ShowScenarioPanel>().getLevelDescription();
    //         descriptionTxt.text = txt;
    //     }else{
    //         descriptionTxt.text = tmp;
    //     }

        
    // }



    public void acceptMission(){
        if(missionStatus==3){
            SceneManager.LoadScene("Menu");
        }else{
            SCENARIO.GetComponent<ShowScenarioPanel>().starGenerator();
            setStatus(2);
        }
        
    }



}
