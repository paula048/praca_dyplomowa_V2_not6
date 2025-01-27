using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public Texture red;
    public Texture green;

    public RawImage level1;
    public RawImage level2;
    public RawImage level3;

    public RawImage[] batteryLevels;

    private int levelValue2 = 5;
    private int levelmax = 5;

    void Start()
    {
        for(int i = 0; i<batteryLevels.Length; i++){
            batteryLevels[i].texture = green;
        }
    }


    public void decreaseLevel()
    {
        if(levelValue2>0){
            batteryLevels[levelValue2-1].texture = red;
            levelValue2--;
            Debug.Log("Battery reduce  -------------");
        }

        if(levelValue2==0){
            Debug.Log("QUIT ---------------");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }


    public void increaseLevel()
    {
        if(levelValue2<levelmax){
            levelValue2++;
            batteryLevels[levelValue2-1].texture = green;
            Debug.Log("Battery increase  -------------");
        }  
    }



    void Update()
    {
        
    }
}
