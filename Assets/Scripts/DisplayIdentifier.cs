using UnityEngine;
using System.Collections;

using UXF;

public class DisplayIdentifer : MonoBehaviour

{
void Start()
{
    for (int i = 0; i < Display.displays.Length; i++)
    {
        Debug.Log("Display " + i + ": " + Display.displays[i].renderingWidth + "x" + Display.displays[i].renderingHeight);
    }
}
}