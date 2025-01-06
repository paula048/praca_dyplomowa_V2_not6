using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScenarioPanel : MonoBehaviour
{
    public List<LevelDescription> levelsDetails;
    public List<GameObject> triggerActivate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable] 
public class LevelDescription 
{ 
    public int quantityOfFrogsFrom; 
    public int quantityOfFrogsTo; 
}
