using UnityEngine;
using TMPro; // Import TextMeshPro namespace.

public class TerrainUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI trialDisplayText; // Reference to the TextMeshProUGUI element.

    private void OnEnable()
    {
        // Subscribe to the terrain file update event.
        TerrainFileNotifier.OnTerrainFileUpdated += UpdateTerrainDisplay;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks.
        TerrainFileNotifier.OnTerrainFileUpdated -= UpdateTerrainDisplay;
    }

    // This method will be called to update the UI with the new terrain file name.
    public void UpdateTerrainDisplay(string terrainFileName)
    {
        trialDisplayText.text = "Current Terrain File: " + terrainFileName;
        Debug.Log("Updated UI with terrain file: " + terrainFileName);
    }
}
