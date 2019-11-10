using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject buttonsLight;
    public Animator doorRef;

    // Start is called before the first frame update
    void Start()
    {
        doorRef.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            buttonsLight.SetActive(false);
            doorRef.SetBool("DoorOpening", true);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
