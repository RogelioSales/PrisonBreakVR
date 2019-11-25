using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExit : MonoBehaviour
{
    public GameObject brickRef;
    public GameObject keyToSpawn;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == brickRef)
        {
            Instantiate(keyToSpawn, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
