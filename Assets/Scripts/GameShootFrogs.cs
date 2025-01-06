using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShootFrogs : MonoBehaviour
{
    public bool startTrigger = false;
    public GameObject frogModel;
    public int numberOfFrog = 20;
    public List<Material> frogColors;
    public List<GameObject> places;
    public List<PlacePosition> CoordsPositions;
    private Transform coord1;
    private Transform coord2;


    private int aliveFrogs;

    void Start()
    {
        if (startTrigger)
        {
            generateFrog();
        }

        if(coord1 != null){
            Debug.Log("TEST COORDS: " + coord1.position.x);
        }

        
    }

    void Update()
    {
        
    }



    private void extractCoordsFromPlaces(){
        // if exist             --- warunek


        foreach(GameObject place in places){
            Transform pos1 = place.transform.Find("Coord 1"); 
            Transform pos2 = place.transform.Find("Coord 2"); 

            // Check if both transforms are found 
            if (pos1 != null && pos2 != null) 
            { 
                CoordsPositions.Add(new PlacePosition(pos1, pos2));
            } 
            else 
            { 
                Debug.LogError("One or both positions could not be found."); 
            }

        }


    }


    private void HandleFrogDeath()
    {
        aliveFrogs--;

        if (aliveFrogs <= 0)
        {
            Debug.Log("You kill all FROGS");
        }
    }




    private void isAnyPlaces(){
        if(places != null){
            selectPlace(CoordsPositions[randomPlace()]);
        }
    }

    private int randomPlace(){
        int placeNumber = Random.Range(0, places.Count);
        return placeNumber;
    }

    private void selectPlace(PlacePosition place){
        coord1 = place.coord1;
        coord2 = place.coord2;
    }


    public void generateFrog()
    {
        extractCoordsFromPlaces();
        isAnyPlaces();

        aliveFrogs = numberOfFrog;

        for (int i = 0; i < numberOfFrog; i++)
        {
            GameObject thisFrog = Instantiate(frogModel, randPosition(), Quaternion.Euler(0f, randRotation(), 0f));
            Frog frogScript = thisFrog.GetComponent<Frog>();
            if (frogScript != null)
            {
                Material mat = randMaterial();
                frogScript.setMaterial(mat);

                // Subscribe to the frog's death event
                frogScript.OnDeath += HandleFrogDeath;

                // Get the Animator component
                Animator frogAnimator = thisFrog.GetComponent<Animator>();
                if(frogAnimator != null){
                    // Set a random start time for the animation
                    float randomStart = Random.Range(0f, frogAnimator.GetCurrentAnimatorStateInfo(0).length);
                    frogAnimator.Play(0, -1, randomStart); 
                }
                
            }
            else
            {
                Debug.LogError("Frog script not found on the instantiated 'Frog' object.");
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







    private Vector3 randPosition()
    {
        var resultX = min_max(coord1.position.x, coord2.position.x);
        var resultY = min_max(coord1.position.y, coord2.position.y);
        var resultZ = min_max(coord1.position.z, coord2.position.z);
        return new Vector3(Random.Range(resultX.min, resultX.max), Random.Range(resultY.min, resultY.max), Random.Range(resultZ.min, resultZ.max));
    }

    private float randRotation()
    {
        return Random.Range(0f, 360.0f);
    }

    private Material randMaterial()
    {
        int position = Random.Range(0, frogColors.Count);
        return frogColors[position];
    }

}




[System.Serializable] 
public class PlacePosition 
{ 
    public Transform coord1; 
    public Transform coord2; 

    public PlacePosition(Transform cor1, Transform cor2){
        coord1 = cor1;
        coord2 = cor2;
    }
}
