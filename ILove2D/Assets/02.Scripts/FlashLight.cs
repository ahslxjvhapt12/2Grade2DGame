using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    float t1;
    float t2;
    float t3;
    [Header("��� �ð�")]
    [SerializeField] private float t = 0;

    [SerializeField] private GameObject bomb;
    [SerializeField] private Light2D _light;

    [Header("�ֱ�")]
    [SerializeField] float speed1;
    [SerializeField] float speed2;
    [SerializeField] float speed3;

    [Header("��")]
    [SerializeField] float p1;
    [SerializeField] float p2;
    [SerializeField] float p3;
    private void Update()
    { 
        t1 += Time.deltaTime * speed1; // �ﰢ�Լ� 1�� �ֱ�
        t2 += Time.deltaTime * speed2; // �ﰢ�Լ� 2�� �ֱ�
        t3 += Time.deltaTime * speed3; // �ﰢ�Լ� 3�� �ֱ�

        float f1 = Mathf.Cos(t1) * p1; // �ﰢ�Լ� 1�� ��
        float f2 = Mathf.Cos(t2) * p2; // �ﰢ�Լ� 2�� ��
        float f3 = Mathf.Cos(t3) * p3; // �ﰢ�Լ� 3�� ��
        // �ﰢ�Լ��� ���ϰ� ����ȭ�� �� = sum
        float sum = ((f1 + f2 + f3) / (p1 + p2 + p3)) * 0.5f + 0.5f; 
        _light.intensity = sum; // ���� ��⸦ sum ����
        _light.color = new Color(f1, f2, f3, 1); // ���� ���� �� �ﰢ�Լ��� ���������

        Debug.Log(f1);
        t += Time.deltaTime;
        if (t > 9) t = -9;
        bomb.transform.position = new Vector2(t, sum * 3);
    }
}
