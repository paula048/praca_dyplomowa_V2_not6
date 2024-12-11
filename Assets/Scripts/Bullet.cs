using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Material colorr;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Frog"))
        {
            Frog frogScript = collision.gameObject.GetComponent<Frog>();
            if (frogScript != null)
            {
                frogScript.Death();
                Destroy(gameObject);

            }
            else
            {
                Debug.LogError("Frog script not found on the 'Frog' object.");
            }

        }
    }
    
}
