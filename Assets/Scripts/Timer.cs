using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class TimerStart : MonoBehaviour
{
    public Session session;
    public AudioClip failSound;
    public float timer_length;

    public void BeginCountdown()
    {
        StartCoroutine(Countdown());
    }

    public void StopCountdown()
    {
        StopAllCoroutines();
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timer_length);

        // if we got to this stage, that means we moved too slow
        session.CurrentTrial.result["outcome"] = "tooslow";
        session.EndCurrentTrial();

        // we will play a clip at position above origin, 100% volume
        AudioSource.PlayClipAtPoint(failSound, new Vector3(0, 1.3f, 0), 1.0f);
    }
}
