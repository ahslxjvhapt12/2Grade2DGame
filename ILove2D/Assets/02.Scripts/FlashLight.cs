using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    float t1;
    float t2;
    float t3;
    [Header("경과 시간")]
    [SerializeField] private float t = 0;

    [SerializeField] private GameObject bomb;
    [SerializeField] private Light2D _light;

    [Header("주기")]
    [SerializeField] float speed1;
    [SerializeField] float speed2;
    [SerializeField] float speed3;

    [Header("폭")]
    [SerializeField] float p1;
    [SerializeField] float p2;
    [SerializeField] float p3;

    bool pause = false;

    private void Update()
    {
        if (pause) return;
        t1 += Time.deltaTime * speed1;
        t2 += Time.deltaTime * speed2;
        t3 += Time.deltaTime * speed3;

        float f1 = Mathf.Cos(t1) * p1;
        float f2 = Mathf.Cos(t2) * p2;
        float f3 = Mathf.Cos(t3) * p3;

        float sum = ((f1 + f2 + f3) / (p1 + p2 + p3)) * 0.5f + 0.5f;
        _light.intensity = sum;
        t += Time.deltaTime;
        _light.color = new Color(f1, f2, f3, 1);

        if (t > 9) t = -9;

        bomb.transform.position = new Vector2(t, sum * 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerHitCol")
        {
            Debug.Log(collision.transform.name);
            if (Vector2.Dot(collision.transform.position, transform.up) > 0)
            {
                Debug.Log("위");
                pause = !pause;
            }
        }
    }
}
