using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    private LineRenderer currLine;

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = new GameObject();
            currLine = go.AddComponent<LineRenderer>();

        }
    }
}
