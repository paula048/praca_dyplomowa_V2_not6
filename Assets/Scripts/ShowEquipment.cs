using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.XR.Interaction.Toolkit;


public class ShowEquipment : MonoBehaviour
{
    public XRDirectInteractor rightHandInteractor;
    public InputActionReference openButton; 
    public InputActionReference addToButton; 
    public InputActionReference scrollButton; 
    public GameObject bagPanel;
    public GameObject pointToGenerate;
    public bool showInfo = false;
    public GameObject InfoCanvas;

    public List<GameObject> objectsList;
    
    private InfoPanel infoPanel;        // metod from script InfoPanel
    private bool isOpenBag = false;
    private int currentIndex = 0;


    private GameObject actualGrabbedItem = null;

    private void OnEnable() 
    { 
        openButton.action.performed += OnButtonBPressed; 
        addToButton.action.performed += OnButtonAPressed; 
        scrollButton.action.performed += OnButtonScrollPressed; 

        if (rightHandInteractor != null)
        {
            rightHandInteractor.selectEntered.AddListener(OnGrab);
            rightHandInteractor.selectExited.AddListener(OnRelease);
        }
    } 
    private void OnDisable() 
    { 
        openButton.action.performed -= OnButtonBPressed; 
        addToButton.action.performed -= OnButtonAPressed; 
        scrollButton.action.performed -= OnButtonScrollPressed; 

        if (rightHandInteractor != null)
        {
            rightHandInteractor.selectEntered.RemoveListener(OnGrab);
            rightHandInteractor.selectExited.RemoveListener(OnRelease);
        }
    } 

    // OnGrab i OnRelease dodaje i usuwa obiekt z Listy
    private void OnGrab(SelectEnterEventArgs args)
    {
        GameObject grabbedObject = args.interactableObject.transform.gameObject;
        this.actualGrabbedItem = grabbedObject;

        Debug.Log($"Grabbed: {grabbedObject.name}");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        GameObject releasedObject = args.interactableObject.transform.gameObject;
        this.actualGrabbedItem = null;
        Debug.Log($"Released: {releasedObject.name}");
    }




    private void OnButtonBPressed(InputAction.CallbackContext context) 
    { 
        Debug.Log("Clicked Button B");
        if(isOpenBag){
            CloseBag();
        }
        else{
            OpenBag();
        }
    }

    private void OnButtonAPressed(InputAction.CallbackContext context) 
    { 
        Debug.Log("Clicked Button To Add Item To List");
        if(actualGrabbedItem != null){
            Debug.Log("IS Actual Grabbed");
            if(showInfo){
                InfoCanvas.GetComponent<InfoPanel>().showInformation("Item added to Equipment");
            }
            AddItemToEquipment();
            
        }
    }

    private void OnButtonScrollPressed(InputAction.CallbackContext context) 
    { 
        Debug.Log("Clicked ButtonToScroll");
        if(isOpenBag){
                int actualIndex = this.currentIndex;
                if(objectsList != null){
                    HiddenItem(actualIndex);
                    actualIndex++;
                    if(actualIndex >= objectsList.Count){
                        actualIndex = 0;  
                    }
                    this.currentIndex = actualIndex;       
                    ShowItem(actualIndex);
                }
        }
        else{
            OpenBag();
        }
        
    }


    // private void showInformation(int time = 4){
    //     if(InfoCanvas != null){
    //         InfoCanvas
    //     }
    // }
    // private void showInfo(){
    //     if(InfoCanvas != null){
    //         InfoCanvas
    //     }
    // }

    // IEnumerator ExampleCoroutine(int time = 4)
    // {

    //     yield return new WaitForSeconds(time);

    //     ClearCollisionList();
    // }


    private void AddItemToEquipment(){

        if (!objectsList.Contains(actualGrabbedItem))
        {
            objectsList.Add(actualGrabbedItem);
            actualGrabbedItem.SetActive(false);    
        }

    }


    private void ShowItem(int index){
        if(index < objectsList.Count){
            // objectsList[index].transform.position = new Vector3(122f, 51f, 453f);
            objectsList[index].transform.position = new Vector3(pointToGenerate.transform.position.x, pointToGenerate.transform.position.y, pointToGenerate.transform.position.z);

            objectsList[index].SetActive(true);
        }
        
    }

    private void HiddenItem(int index){
        objectsList[index].SetActive(false);
    }

    private void OpenBag(){
        bagPanel.SetActive(true);
        isOpenBag = true;

        if(objectsList != null){    // If Any Exist
            ShowItem(currentIndex);
        }
    }

    private void CloseBag(){
        
bagPanel.SetActive(false);
        isOpenBag = false;
        // is item was taken from Equipment
        bool request = pointToGenerate.GetComponent<DetectCollectItem>().isItemTaken(objectsList[currentIndex]);
        if(request){
            objectsList.RemoveAt(currentIndex);
            Debug.Log("Request: true");
        }
        else{
            HiddenItem(currentIndex);
            Debug.Log("Request: flase");
        }

        
        
    }

    void Start()
    {
        bagPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
