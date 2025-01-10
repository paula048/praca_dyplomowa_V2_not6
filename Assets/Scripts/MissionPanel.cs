using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    public GameObject SCENARIO;
    public TMP_Text statusTxt;
    public TMP_Text descriptionTxt;
    public int missionStatus = 0;       // 0-not active, 1-activated, 2-while during ...
    void Start()
    {
        setDescription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setStatus(int status){

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
        
    }


    public void setDescription(){

        setStatus(0);
        string txt = SCENARIO.GetComponent<ShowScenarioPanel>().getLevelDescription();
        descriptionTxt.text = txt;
    }

    public void acceptMission(){
        SCENARIO.GetComponent<ShowScenarioPanel>().starGenerator();
        setStatus(2);
    }



}
