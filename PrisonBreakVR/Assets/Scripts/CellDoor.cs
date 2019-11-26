using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoor : MonoBehaviour
{
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
            doorRef.SetBool("CellDoorOpening", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
