using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomButtonLights : MonoBehaviour {

    public float minAnimationTime, maxAnimationTime, minTimeOn, maxTimeOn, minTimeOff, maxTimeOff;

    public List<ButtonLightController> buttons;
    private bool display = false;

	// Use this for initialization
	void Start ()
   {
        foreach (var b in buttons)
            StartCoroutine(RandomIlluminate(b));
	}

    public void Play()
    {
        display = true;
    }

    public void Stop()
    {
        display = false;
    }

	// Update is called once per frame
	IEnumerator RandomIlluminate(ButtonLightController light) {
        bool on = true;

        while (true)
        {
            float time = Mathf.Lerp(minAnimationTime, maxAnimationTime, Random.Range(0f, 1f));

            if (on && display)
            {
                light.TurnOn(time);
                Debug.Log("Waiting on");
                yield return new WaitForSeconds(time + Mathf.Lerp(minTimeOn, maxTimeOn, Random.Range(0f, 1f)));
            }
            else
            {
                light.TurnOff(time);
                Debug.Log("Waiting off");
                yield return new WaitForSeconds(time + Mathf.Lerp(minTimeOff, maxTimeOff, Random.Range(0f, 1f)));
            }

            on = !on;
        }
	}
}
