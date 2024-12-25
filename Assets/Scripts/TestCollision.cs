using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    public GameObject FrogPrefab; 
    public int rows = 3; public int columns = 3; 
    public float spacing = 1.5f; // Adjust the spacing as needed 
    public Vector3 initialPosition;
    void Start() 
    { 
        SpawnFrogGrid(); 
    } 

    void SpawnFrogGrid() 
    { 
        // Vector3 prefabSize = GetPrefabSize(FrogPrefab); 
        // float spacingX = prefabSize.x; 
        // float spacingZ = prefabSize.z;

        
        for (int row = 0; row < rows; row++) 
        { 
            for (int col = 0; col < columns; col++) 
            { 
                Vector3 position = new Vector3(initialPosition.x + col * spacing, initialPosition.y, initialPosition.z + row * spacing); 
                Instantiate(FrogPrefab, position, Quaternion.identity); 
            } 
        } 
    }

    Vector3 GetPrefabSize(GameObject prefab) { // Instantiate the prefab temporarily to measure its size 
        GameObject tempInstance = Instantiate(prefab); 
        Renderer renderer = tempInstance.GetComponent<Renderer>(); 
        Vector3 size = renderer.bounds.size; Destroy(tempInstance); 
        return size; 
    }
}
