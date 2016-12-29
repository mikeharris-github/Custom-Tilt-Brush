﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private MeshLineRenderer currLine;
    private int numClicks = 0;
    public Material lMat;

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            // this logic is taken from the MeshLineRenderer script
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();

            //set the material to use when the trigger is touched
            currLine.lmat = lMat;
            numClicks = 0;
        }
        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            // currLine.SetVertexCount (numClicks + 1);
            // currLine.SetPosition(numClicks, trackedObj.transform.position);

            currLine.AddPoint(trackedObj.transform.position);
            numClicks++;
        }

        if (currLine != null) //if current line does not equal null
        {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor(); //current line material color equals color manager's current color
        }
    }
}

// graphics line renderer is a better alternative to line renderer
