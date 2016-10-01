using UnityEngine;
using System.Collections;

public class ButtonLightController : MonoBehaviour {

    private const float SECURE_VALUE = 0.001f;

    [Range(0f,1f)]
    public float value;
    public float minIntensity, maxIntensity;
    public Color minEmission, maxEmission;

    public Material forEmission;
    public Light forIntensity;
	
	void Update () {
	    if(forEmission != null)
        {
            Color c = forEmission.GetColor("_EmissionColor");
            forEmission.SetColor("_EmissionColor", Color.Lerp(minEmission, maxEmission, value));
        }

        if(forIntensity != null)
        {
            forIntensity.intensity = Mathf.Lerp(minIntensity, maxIntensity, value);
        }
	}

    public void TurnOn(float animationTime)
    {
        StartCoroutine(ModifyValue(0f, 1f, animationTime));
    }

    public void TurnOff(float animationTime)
    {
        StartCoroutine(ModifyValue(1f, 0f, animationTime));
    }

    private IEnumerator ModifyValue(float from, float to, float time)
    {
        float acumulated = 0f;

        while(Mathf.Abs(value - to) > SECURE_VALUE)
        {
            yield return null;

            acumulated += Mathf.Clamp(acumulated + Time.deltaTime, 0f, time);
            value = Mathf.Lerp(from, to, acumulated / time);
        }

        value = to;
    }
}
