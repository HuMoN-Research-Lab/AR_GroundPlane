using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    public Camera camProjector1;
    public Camera camProjector2;
    public Camera camProjector3;

    void Start()
    {

        // Set CamProjector1 to display on Windows Display 2
        camProjector1.targetDisplay = 2; // Display index starts from 0

        // Set CamProjector2 to display on Windows Display 3
        camProjector2.targetDisplay = 4; // Display index starts from 0

        // Set CamProjector3 to display on Windows Display 4
        camProjector3.targetDisplay = 3; // Display index starts from 0
    }
}
