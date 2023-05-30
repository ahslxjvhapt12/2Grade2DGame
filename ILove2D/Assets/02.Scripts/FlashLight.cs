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
    private void Update()
    { 
        t1 += Time.deltaTime * speed1; // 삼각함수 1의 주기
        t2 += Time.deltaTime * speed2; // 삼각함수 2의 주기
        t3 += Time.deltaTime * speed3; // 삼각함수 3의 주기

        float f1 = Mathf.Cos(t1) * p1; // 삼각함수 1의 폭
        float f2 = Mathf.Cos(t2) * p2; // 삼각함수 2의 폭
        float f3 = Mathf.Cos(t3) * p3; // 삼각함수 3의 폭
        // 삼각함수를 더하고 정규화한 값 = sum
        float sum = ((f1 + f2 + f3) / (p1 + p2 + p3)) * 0.5f + 0.5f; 
        _light.intensity = sum; // 빛의 밝기를 sum 으로
        _light.color = new Color(f1, f2, f3, 1); // 빛의 색을 각 삼각함수의 결과값으로

        Debug.Log(f1);
        t += Time.deltaTime;
        if (t > 9) t = -9;
        bomb.transform.position = new Vector2(t, sum * 3);
    }
}
