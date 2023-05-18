using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KassadinR : MonoBehaviour
{
    Camera mainCam;
    Rigidbody2D _rigid;

    [SerializeField] float mana;
    [SerializeField] float cost;
    [SerializeField] float distance;
    [SerializeField] float currentCool;
    [SerializeField] float cool;

    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI costText;

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI coolText;

    private void Awake()
    {
        mainCam = Camera.main;
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        slider.value = currentCool / cool;
        coolText.text = $"{currentCool : 0.0}s";
        if (currentCool <= 0)
        {
            if (Input.GetMouseButtonDown(1) && mana >= cost)
            {
                mana -= cost;
                cost *= 2;
                manaText.text = $"mana : {mana}";
                costText.text = $"cost : {cost}";
                Vector3 clickPosition = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y));
                //_rigid.AddForce((clickPosition - transform.position).normalized * power, ForceMode2D.Impulse);
                transform.position = new Vector3(
                    (transform.position + (clickPosition - transform.position).normalized * distance).x,
                    (transform.position + (clickPosition - transform.position).normalized * distance).y,
                    0);
                currentCool = cool;
            }
        }
        else
        {
            currentCool -= Time.deltaTime;
        }
    }
}
