using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void scene_goStart(){
        SceneManager.LoadScene("Terrain1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
