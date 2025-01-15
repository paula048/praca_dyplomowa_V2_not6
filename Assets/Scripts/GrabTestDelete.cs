using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTestDelete : MonoBehaviour
{
    public List<GameObject> grabbedObjects = new List<GameObject>();
    public XRDirectInteractor rightHandInteractor;

    private void OnEnable()
    {
        if (rightHandInteractor != null)
        {
            rightHandInteractor.selectEntered.AddListener(OnGrab);
            rightHandInteractor.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        if (rightHandInteractor != null)
        {
            rightHandInteractor.selectEntered.RemoveListener(OnGrab);
            rightHandInteractor.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        GameObject grabbedObject = args.interactableObject.transform.gameObject;
        if (!grabbedObjects.Contains(grabbedObject))
        {
            grabbedObjects.Add(grabbedObject);
            Debug.Log($"Grabbed Sexy: {grabbedObject.name}");
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        GameObject releasedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"Released Sexy: {releasedObject.name}");
    }
}

