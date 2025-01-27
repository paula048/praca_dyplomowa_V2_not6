using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollectItem : MonoBehaviour
{
    public GameObject itemOutside = null;
    public GameObject itemInside = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isItemTaken(GameObject obj){

        // is the same Object
        if(obj == itemOutside){
            itemOutside = null;
            return true;
        }
        else{
            Debug.LogError("Problem with detection. Also another item is inside Equipment Space.");
            return false;
        }
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Hand")) 
        { 
            Debug.Log("ENTER: Item inside Equipment-Space. name: " + other.name);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Hand")) 
        { 
            Debug.Log("EXIT: Item inside Equipment-Space");
            itemInside = null;
            itemOutside = other.gameObject;
        }
        
    }
}
