using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class Frog : MonoBehaviour
{
 private SkinnedMeshRenderer frogRender;
    public Animator frogAnimator;
    public Material material;
    public bool isKilled = false;
    public GameObject pointeCollider;

    public event Action OnDeath;
    




    void Awake() // Use Awake to initialize components before Start   -   to jest konieczne aby przy  Intiatiate odwołać się do tego skrypu
    {
        Transform bodyTransform = gameObject.transform.Find("Body");
        if (bodyTransform != null)
        {
            frogRender = bodyTransform.GetComponent<SkinnedMeshRenderer>();
            if (frogRender == null)
            {
                Debug.LogError("SkinnedMeshRenderer not found on the 'Body' object.");
            }
        }
        else
        {
            Debug.LogError("Child object 'Body' not found on the 'Frog' object.");
        }
    }

    void Start()
    {
        frogAnimator = GetComponent<Animator>();
        Transform bodyTransform = gameObject.transform.Find("Body");

        if (bodyTransform != null)
            {
                SkinnedMeshRenderer skinnedMeshRenderer = bodyTransform.GetComponent<SkinnedMeshRenderer>();
                if (skinnedMeshRenderer != null)
                {
                    frogRender = bodyTransform.GetComponent<SkinnedMeshRenderer>();
                }
                else
                {
                    Debug.LogError("SkinnedMeshRenderer not found on the 'body' object.");
                }
            }
            else
            {
                Debug.LogError("Child object 'body' not found on the 'Frog' object.");
            }

            if(material){
                setMaterial(material);
            }
            else{
                Debug.Log("Material NOT  exist");
            }


    }

    void Update()
    {
        
    }

    public void Death()
    {
        setColor("magenta");

        if(!isKilled){

            if (frogAnimator != null)
            {
                frogAnimator.Play("Kill");
                Debug.Log("Kill Frog");
                this.isKilled = true;


                // Perform death-related actions (e.g., play animation, destroy frog)
                OnDeath?.Invoke(); // Notify the SystemFrogGenerator

                // Destroy(gameObject); // Destroy the frog after death
            }
            else
            {
                Debug.LogError("Animator component not found.");
            }
        }
        
    }







    public void DeathAnim()
    {
        setColor("green");
    }

    public void setColor(string col)
    {
        Color color = Color.white; // Default color in case the specified color is not found
        PropertyInfo colorProperty = typeof(Color).GetProperty(col, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);

        if (colorProperty != null)
        {
            color = (Color)colorProperty.GetValue(null, null);
        }
        else
        {
            Debug.LogWarning("Color not found: " + col);
        }

        if (frogRender != null)
        {
            frogRender.material.color = color;
        }
        else
        {
            Debug.LogError("frogRender is not assigned.");
        }
    }

    public void setMaterial(Material currentMaterial)
    {
        if (frogRender != null)
        {
            frogRender.material = currentMaterial;
        }
        else
        {
            Debug.LogError("frogRender is not assigned.");
        }
    }
}
