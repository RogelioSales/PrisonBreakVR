using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public GameObject ObjectToDeactive;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button")
        {
            ObjectToDeactive.SetActive(false);
        }
    }
}
