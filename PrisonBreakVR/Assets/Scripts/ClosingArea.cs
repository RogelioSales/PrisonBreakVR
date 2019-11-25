using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingArea : MonoBehaviour
{
    public GameObject objectToActive;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            objectToActive.SetActive(true);
        }
    }
}
