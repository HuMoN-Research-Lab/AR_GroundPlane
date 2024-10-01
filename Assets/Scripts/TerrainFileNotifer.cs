using System;
using UnityEngine;

public class TerrainFileNotifier : MonoBehaviour
{
    // Define an event to notify listeners when the terrain file is updated.
    public static event Action<string> OnTerrainFileUpdated;

    // This method will be called by `WriteCSV` to notify the terrain file name.
    public static void NotifyTerrainFileUpdate(string terrainFileName)
    {
        if (OnTerrainFileUpdated != null)
        {
            OnTerrainFileUpdated(terrainFileName);
        }
    }
}
