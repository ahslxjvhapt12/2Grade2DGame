using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    float t1;
    float t2;
    float t3;

    [SerializeField] private Light2D _light;

    [Header("ÁÖ±â")]
    [SerializeField] float speed1;
    [SerializeField] float speed2;
    [SerializeField] float speed3;
    
    [Header("Æø")]
    [SerializeField] float p1;
    [SerializeField] float p2;
    [SerializeField] float p3;

    private void Update()
    {
        t1 += Time.deltaTime * speed1;
        t2 += Time.deltaTime * speed2;
        t3 += Time.deltaTime * speed3;

        float f1 = Mathf.Cos(t1) * p1;
        float f2 = Mathf.Cos(t2) * p2;
        float f3 = Mathf.Cos(t3) * p3;

        float sum = ((f1 + f2 + f3) / (p1 + p2 + p3) * 2) + 2;
        _light.intensity = sum;
    }
}
