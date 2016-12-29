using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//START: THIS SCRIPT IS USED FOR TRANSLATING THE COLOR PICKER TO THE DRAWLINEMANAGER. IF THIS SCRIPT IS VOID, THEN THE DEFAULT COLOR WILL BE USED FOR THE LINEMANAGER.

public class ColorManager : MonoBehaviour {

    public static ColorManager Instance; // this will be the only color manager in our scene at any given point in time.

    void Awake() {
        if (Instance == null) //there are no instances
            Instance = this; //use this instance
    }

    void OnDestroy() {
        if (Instance == this) //there is an existing instance
            Instance = null; //null out the existing instance
    }
    private Color color;

    void OnColorChange(HSBColor color)
    {
        this.color = color.ToColor(); //use the existing color that's selected
    }

    public Color GetCurrentColor() {
        return this.color;
    }
}
