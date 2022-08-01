using UnityEngine;
using System.Collections;

using UXF;

public class ActivateAllDisplays : MonoBehaviour
{
    void Start()
    {
        Debug.Log ("displays connected: " + Display.displays.Length);
            // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
            // Check if additional displays are available and activate each.
    
        for (int i = 1; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate();
            }

        
    }
    
    public void DebugTrial(Trial trial)
    {
        string file_name = trial.settings.GetString("File_Name");
        Debug.Log(file_name);
    }
}
