using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public GameObject _object;
    public int staticY_position;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAtPosition(Vector3 vector){
        _object.SetActive(true);
        Vector3 newPosition = new Vector3(vector.x, staticY_position, vector.z); // Update Y component
        _object.transform.position = newPosition;
    }

    public void hidden(){
        _object.SetActive(false);
    }
}
