using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Eat : MonoBehaviour
{
    private GameObject battery;
    public GameObject infoPanel;


    void Start()
    {
        battery = GameObject.Find("Battery System"); // Make sure the name matches the GameObject name in your scene
        if (battery == null)
        {
            Debug.LogError("Battery GameObject not found!");
            return;
        }
        XRGrabInteractable grabble = GetComponent<XRGrabInteractable>();
        grabble.activated.AddListener(EatNow);
    }

    public void EatNow(ActivateEventArgs arg)
    {
        Debug.Log("Eat fruit");
        battery.GetComponent<Battery>().eat(this.gameObject);
        if(infoPanel!=null){
            infoPanel.GetComponent<InfoPanel>().showInformation("Item Added to Equipment");
        }
    }
}
