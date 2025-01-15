using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    void Start()
    {
        XRGrabInteractable grabble = GetComponent<XRGrabInteractable>();
        grabble.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
