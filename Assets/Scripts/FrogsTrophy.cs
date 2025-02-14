using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogsTrophy : MonoBehaviour
{
    public bool triggerGenerate = false;
    public List<GameObject> trophies;
    public List<Transform> positionsOfTrophies;
    public List<Vector3> positionsOfTrophiesManuallySet;
    private int actualLevel = 0;
    
    void Start()
    {
        if(triggerGenerate){
            showTrophy(0);
            showTrophy(1);
            showTrophy(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTrophy(int index){
        if(index<trophies.Count){
            Debug.Log("Show Troph");
            GameObject troph = Instantiate(trophies[index], getVector(index), Quaternion.identity);
        }
        else{
            Debug.Log("index out of the trophies List's size");
        }
    }

    private Vector3 extractVector(int level){

        return new Vector3(positionsOfTrophies[level].position.x, positionsOfTrophies[level].position.y, positionsOfTrophies[actualLevel].position.z);
    }

    private Vector3 getVector(int level){

        return positionsOfTrophiesManuallySet[level];
    }

}
