﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalSetup : MonoBehaviour
{
    public Camera cameraA;
    public Material cameraMatA;
    public Camera cameraB;
    public Material cameraMatB;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
