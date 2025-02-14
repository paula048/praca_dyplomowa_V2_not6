using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniwersalGenerator : MonoBehaviour
{
    public Vector3 cord1;
    public Vector3 cord2;
    public bool setForAllTheSameArea = false;
    public List<ObjectProperties> modelsToCreate;
    public List<GameObject> allCreatedObjects;
    void Start()
    {
        if(cord1==null || cord2==null){
            this.setForAllTheSameArea = false;
        }
        createObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void createObjects()
    {


        foreach(ObjectProperties obj in modelsToCreate){

                for (int i = 0; i < obj.quantity; i++)
                {
                    Vector3 piv1 = obj.coord1;
                    Vector3 piv2 = obj.coord2;
                    if(setForAllTheSameArea){
                        piv1 = cord1;
                        piv2 = cord2;
                    }

                    GameObject newObj = Instantiate(obj.model, randPosition(piv1, piv2), Quaternion.Euler(0f, randRotation(), 0f));
                    allCreatedObjects.Add(newObj);     // add frog to list
                }

        }

        
    }



    public (float min, float max) min_max(float a, float b)
    {
        if(b<a){
            return (b, a);
        }
        return (a, b);
    }







    private Vector3 randPosition(Vector3 coord1, Vector3 coord2)
    {
        var resultX = min_max(coord1.x, coord2.x);
        var resultY = min_max(coord1.y, coord2.y);
        var resultZ = min_max(coord1.z, coord2.z);
        return new Vector3(Random.Range(resultX.min, resultX.max), Random.Range(resultY.min, resultY.max), Random.Range(resultZ.min, resultZ.max));
    }



    private float randRotation()
    {
        return Random.Range(0f, 360.0f);
    }



    public void generateFrog()
    {


        // aliveFrogs = numberOfFrog;

        // for (int i = 0; i < numberOfFrog; i++)
        // {
        //     GameObject thisFrog = Instantiate(frogModel, randPosition(), Quaternion.Euler(0f, randRotation(), 0f));
        //     createdFrogs.Add(thisFrog);     // add frog to list
        //     Frog frogScript = thisFrog.GetComponent<Frog>();
        //     if (frogScript != null)
        //     {
        //         Material mat = randMaterial();
        //         frogScript.setMaterial(mat);

        //         // Subscribe to the frog's death event
        //         frogScript.OnDeath += HandleFrogDeath;

        //         // Get the Animator component
        //         Animator frogAnimator = thisFrog.GetComponent<Animator>();
        //         if(frogAnimator != null){
        //             // Set a random start time for the animation
        //             float randomStart = Random.Range(0f, frogAnimator.GetCurrentAnimatorStateInfo(0).length);
        //             frogAnimator.Play(0, -1, randomStart); 
        //         }
                
        //     }
        //     else
        //     {
        //         Debug.LogError("Frog script not found on the instantiated 'Frog' object.");
        //     }
        // }
    }







}




[System.Serializable] 
public class ObjectProperties 
{ 
    public GameObject model;
    public int quantity = 1;
    public Vector3 coord1; 
    public Vector3 coord2; 


    // public ObjectProperties(Transform cor1, Transform cor2){
    //     coord1 = cor1;
    //     coord2 = cor2;
    // }
}
