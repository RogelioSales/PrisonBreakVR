using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject breakVersion;
    public bool isBreaking = false;

    private void Update()
    {
        Breaking();
    }
    void Breaking()
    {
        if (isBreaking)
        {
            Instantiate(breakVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
