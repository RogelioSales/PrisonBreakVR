﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        float angularDifferenceBetweenPortals = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortals, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
