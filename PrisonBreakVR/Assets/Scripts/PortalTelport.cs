using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTelport : MonoBehaviour
{
    //public Transform player;
    //public Transform receiver;
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    private bool playerIsOverlap;
    // Update is called once per frame
    void Update()
    {
        //if (playerIsOverlap)
        //{
        //    Vector3 portalToPlayer = player.position - transform.position;
        //    float dotProduct = Vector3.Dot(transform.up, portalToPlayer);


        //    if(dotProduct < 0f)
        //    {
        //        float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
        //        rotationDiff += 180;
        //        player.Rotate(Vector3.up, rotationDiff);

        //        Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
        //        player.position = receiver.position + positionOffset;
        //        playerIsOverlap = false;
        //    }
        //}
        if (playerIsOverlap)
        {
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlap = true;
            
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        playerIsOverlap = false;
           

    //    }
    //}
}
