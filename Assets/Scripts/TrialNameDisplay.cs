using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class TrialNameDisplay : MonoBehaviour
{
    public TextMeshPro textMeshPro;  // Reference to the TextMeshPro component

    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component is not assigned in the inspector!");
        }
    }

    public void UpdateTrialNameDisplay(string trialName)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = trialName;
            Debug.Log("Updated Trial Name on UI: " + trialName);
        }
        else
        {
            Debug.LogError("TextMeshPro component is not assigned!");
        }
    }
}
