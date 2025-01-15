using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.UI;

public class EquipmentSystem : MonoBehaviour 
{ 
    public InputActionReference buttonBAction; 
    public GameObject equipmentPanel; 
    public Transform equipmentContent; 
    public GameObject itemPrefab; // A prefab with a UI representation of an item (e.g., a button or an icon) 
    public List<GameObject> playerInventory = new List<GameObject>(); 
    private void OnEnable() { buttonBAction.action.performed += OnButtonBPressed; } 
    private void OnDisable() { buttonBAction.action.performed -= OnButtonBPressed; } 
    private void OnButtonBPressed(InputAction.CallbackContext context) 
    { 
        if (equipmentPanel.activeSelf) 
        { 
            CloseEquipmentPanel(); 
        } else 
        { 
            OpenEquipmentPanel(); 
        } 
    } 

    private void OpenEquipmentPanel() 
    { 
        equipmentPanel.SetActive(true); PopulateEquipmentPanel(); 
    } 
    
    private void CloseEquipmentPanel() 
    { 
        equipmentPanel.SetActive(false); 
    } 
    
    private void PopulateEquipmentPanel() 
    { 
        foreach (Transform child in equipmentContent) 
        { 
            Destroy(child.gameObject); 
        } 

        foreach (GameObject item in playerInventory) 
        { 
            GameObject itemObject = Instantiate(itemPrefab, equipmentContent); 
            itemObject.GetComponentInChildren<Text>().text = item.name; 
            Button itemButton = itemObject.GetComponent<Button>(); 
            itemButton.onClick.AddListener(() => TakeItem(item)); 
        } 
    } 
    private void TakeItem(GameObject item) { 
        playerInventory.Remove(item); CloseEquipmentPanel(); 

        // Add logic to give the item to the player 
        Debug.Log($"Took {item.name} from equipment."); 
    } 
}

