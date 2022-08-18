using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialSuccess : MonoBehaviour
{
    public AudioClip happy_sound;

    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        StopAllCoroutines();
        Debug.Log("Trial Success!");
        AudioSource.PlayClipAtPoint(happy_sound, transform.position, 1.0f);

    }
}
