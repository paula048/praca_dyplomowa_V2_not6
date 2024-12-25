using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioPanelTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     speed = speed * -1;
    // }

    // Reference to the Canvas GameObject 
    public GameObject canvas; 
    // This method is called when another collider enters the trigger collider attached to this GameObject 
    private void OnTriggerEnter(Collider other) { 

        Debug.Log("Collision !");
        // Check if the collider that triggered the event has the tag "Player" (or any tag you want to specify) 
        if (other.CompareTag("Player")) { 
            Debug.Log("I see Player");
            // Set the Canvas GameObject to be active (visible) 
            canvas.SetActive(true); } 
        }
}
