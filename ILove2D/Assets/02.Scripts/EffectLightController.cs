using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EffectLightController : MonoBehaviour
{
    Light2D _light;
    float t = 0;
    private void Awake()
    {
        _light = GetComponent<Light2D>();
        t = 0;
    }
    private void Update()
    {
        t += Time.deltaTime;
        _light.intensity = Mathf.Lerp(_light.intensity, 0, t) + 0.5f;
    }
}
