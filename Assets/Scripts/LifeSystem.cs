using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject battery;
    public int BreakTimeBetweenCollision = 3;
    public bool isKilledFrogStillToxic = true;
    private Battery toDo2Script;  // Reference to ToDo2 script

    void Start()
    {
        // battery = GameObject.Find("BatterySystem");

        if (battery != null)
        {
            toDo2Script = battery.GetComponent<Battery>();  // Get the ToDo2 script from battery
            if (toDo2Script == null)
            {
                Debug.LogError(" 'Battery' script not found on batterySyestem");
            }else{
                Debug.LogError(" 'Battery' script is founded !");
            }
        }
        else
        {
            Debug.LogError("battery is not assigned.");
        }
    }





    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("colision Trigger");
    //     Renderer rend = GetComponent<Renderer>();

    //     if (other.CompareTag("TrapeCollider"))
    //     {
    //         rend.material.color = Color.blue;
    //         Debug.Log("Entered TRIGGER collision with " + other.gameObject.name);
    //         CallMakeCoffee();

    //     }
    // }




    public void CallMakeCoffee()
    {
        if (toDo2Script != null)
        {
            toDo2Script.decreaseLevel();  // Call makeCoffe function from ToDo2 script
        }
    }




    private HashSet<GameObject> collidedTrapeColliders = new HashSet<GameObject>();

    // void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     if (hit.gameObject.tag == "Frog" && !collidedTrapeColliders.Contains(hit.gameObject))
    //     {
    //         collidedTrapeColliders.Add(hit.gameObject);
    //         Renderer rend = hit.gameObject.GetComponent<Renderer>();
    //         if (rend != null)
    //         {
    //             rend.material.color = Color.blue;
    //         }
    //         Debug.Log("LOVE ------------------------ Trape");

    //         CallMakeCoffee();
    //     }
    // }


    private void ClearCollisionList(){
        collidedTrapeColliders.Clear();
    }




    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(BreakTimeBetweenCollision);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        ClearCollisionList();
    }




    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Frog" && !collidedTrapeColliders.Contains(hit.gameObject))
        {
            
            if(hit.gameObject.GetComponent<Frog>().isKilled){

                if(isKilledFrogStillToxic){
                    collidedTrapeColliders.Add(hit.gameObject);
                    Renderer rend = hit.gameObject.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.material.color = Color.blue;
                    }
                    Debug.Log(" ------------------------ Collision with Frog");
                    StartCoroutine(ExampleCoroutine());

                    CallMakeCoffee();
                }

                    

            }
            else{
                    collidedTrapeColliders.Add(hit.gameObject);
                    Renderer rend = hit.gameObject.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.material.color = Color.blue;
                    }
                    Debug.Log(" ------------------------ Collision with Frog");
                    StartCoroutine(ExampleCoroutine());

                    CallMakeCoffee();
            }

            
        }
    }


}
