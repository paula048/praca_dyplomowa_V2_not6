
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattery : MonoBehaviour
{
    public Texture red;
    public Texture green;

    public RawImage level1;
    public RawImage level2;
    public RawImage level3;

    public RawImage[] batteryLevels;

    public AudioSource audioSource; // Assign in Inspector
    public float eatinfTime = 5f;

    private int levelValue2 = 5;
    private int levelmax = 5;

    void Start()
    {
        levelValue2 = batteryLevels.Length;
        levelmax = batteryLevels.Length;

        for(int i = 0; i<batteryLevels.Length; i++){
            batteryLevels[i].texture = green;
        }
    }


    public void decreaseLevel()
    {
        if(levelValue2>0){
            batteryLevels[levelValue2-1].texture = red;
            levelValue2--;
            Debug.Log("Battery reduce  -------------");
        }

        if(levelValue2==0){
            Debug.Log("You killed BOSS FROG ---------------");
            // Application.Quit();
            // UnityEditor.EditorApplication.isPlaying = false;
        }
    }


    public void increaseLevel()
    {
        if(levelValue2<levelmax){
            levelValue2++;
            batteryLevels[levelValue2-1].texture = green;
            Debug.Log("Battery increase  -------------");
        }  
    }

    public void eat(GameObject obj)
    {
        Debug.Log("Eat fruit");
        StartCoroutine(PlayMusicForTime(eatinfTime));
        obj.SetActive(false);
    }


    IEnumerator PlayMusicForTime(float duration)
    {
        audioSource.Play();
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
        increaseLevel();
    }



    void Update()
    {
        
    }
}

