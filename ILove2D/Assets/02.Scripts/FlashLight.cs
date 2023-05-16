using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    float t;
    [SerializeField] private Light2D _light;

    private void Update()
    {
        t += Time.deltaTime;

        _light.intensity = (Mathf.Cos(t) + 1) * 3f;
    }
}
