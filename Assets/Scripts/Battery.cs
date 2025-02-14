using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Battery : MonoBehaviour
{
    public Texture red;
    public Texture green;

    public RawImage level1;
    public RawImage level2;
    public RawImage level3;

    public RawImage[] batteryLevels;

    public AudioSource audioSourceEat; // Assign in Inspector
    public AudioSource audioSourceLifeUp;
    public AudioSource audioSourceLifeDown;
    public GameObject InfoPanel;
    public float eatinfTime = 5f;

    private int levelValue2 = 5;
    private int levelmax = 5;

    void Start()
    {
        for(int i = 0; i<batteryLevels.Length; i++){
            batteryLevels[i].texture = green;
        }
    }


    public void decreaseLevel()
    {
        audioSourceLifeDown.Play();
        if(levelValue2>0){
            batteryLevels[levelValue2-1].texture = red;
            levelValue2--;
            Debug.Log("Battery reduce  -------------");
        }

        if(levelValue2==0){
            
            Debug.Log("QUIT ---------------");
            if(InfoPanel!=null){
                InfoPanel.GetComponent<InfoPanel>().showInformation("Game Over. Your journey ends here.");
            }
            StartCoroutine(EndGame(5f));

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


        IEnumerator EndGame(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Menu");

    }


    IEnumerator PlayMusicForTime(float duration)
    {
        audioSourceEat.Play();
        yield return new WaitForSeconds(duration);
        audioSourceEat.Stop();
        increaseLevel();
        StartCoroutine(PlayMusicLevelUp(eatinfTime));
    }

    IEnumerator PlayMusicLevelUp(float duration)
    {
        audioSourceLifeUp.Play();
        yield return new WaitForSeconds(duration);
        audioSourceLifeUp.Stop();
    }

    IEnumerator PlayMusicLevelDown(float duration)
    {
        audioSourceLifeDown.Play();
        yield return new WaitForSeconds(duration);
        audioSourceLifeDown.Stop();
    }

    private void animationLevelUp(){

    }



    void Update()
    {
        
    }
}
