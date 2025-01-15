using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
public class ClickButtonXR : MonoBehaviour 
{ 
    public InputActionReference buttonBAction; 
    private void OnEnable() 
    { 
        buttonBAction.action.performed += OnButtonBPressed; 
        } 
        private void OnDisable() 
        { 
            buttonBAction.action.performed -= OnButtonBPressed; 
            } 
            private void OnButtonBPressed(InputAction.CallbackContext context) 
{ 
    Debug.Log("Clicked Button B");
}
}


