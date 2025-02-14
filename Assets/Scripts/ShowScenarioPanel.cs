using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScenarioPanel : MonoBehaviour
{
    public GameObject GENERATOR;
    public GameObject VIEW_PANEL;
    public GameObject TROPHIES;
    public List<LevelDescription> levelsDetails;
    public List<GameObject> randomPlaces;
    public int numberOfLevels = 3;
    public int currentLevel = 0;
    private string endGameText = "The frog plague is no more. You did what had to be done. But was it the right choice? Only time will tell...";
    void Start()
    {
        
    }

        void Awake() {
    DynamicGI.UpdateEnvironment();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementLevel(){
        if(currentLevel+1<numberOfLevels){  // istnieje nastepny Level
            TROPHIES.GetComponent<FrogsTrophy>().showTrophy(currentLevel);                     // unlock Trophies
            currentLevel++;
            updatePanelText();
            Debug.Log("UPDATE Level to: "+ currentLevel);
        }
        else{
            Debug.Log("END Game !!!!!!!!!!");
            TROPHIES.GetComponent<FrogsTrophy>().showTrophy(currentLevel);
            VIEW_PANEL.GetComponent<MissionPanel>().setStatus(3);
            VIEW_PANEL.GetComponent<MissionPanel>().setTitle("Congratulations!");
            VIEW_PANEL.GetComponent<MissionPanel>().SetBackgroundColor(Color.red);
            VIEW_PANEL.GetComponent<MissionPanel>().setDescription(endGameText);
        }
    }

    private void updatePanelText(){
        VIEW_PANEL.GetComponent<MissionPanel>().setDescription();
    }

    public void starGenerator(){
        GENERATOR.GetComponent<GameShootFrogs>().numberOfFrog = randomQuantity();
        GENERATOR.GetComponent<GameShootFrogs>().generateFrog();
    }



    private int randomQuantity(){
        int min = levelsDetails[currentLevel].quantityOfFrogsFrom;
        int max = levelsDetails[currentLevel].quantityOfFrogsTo;

        return Random.Range(min, max);
    }

    public string getLevelDescription(){
        return levelsDetails[currentLevel].missionPanelTxt;
    }
}


[System.Serializable] 
public class LevelDescription 
{ 
    public int quantityOfFrogsFrom; 
    public int quantityOfFrogsTo; 
    
    public string missionPanelTxt;
}
