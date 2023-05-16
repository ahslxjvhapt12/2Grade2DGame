using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KassadinR : MonoBehaviour
{
    Camera mainCam;
    Rigidbody2D _rigid;

    [SerializeField] float mana;
    [SerializeField] float cost;
    [SerializeField] float power;

    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI costText;

    private void Awake()
    {
        mainCam = Camera.main;
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && mana >= cost)
        {
            mana -= cost;
            cost *= 2;
            manaText.text = $"mana : {mana}";
            costText.text = $"cost : {cost}";
            Vector3 clickPosition = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y));
            _rigid.AddForce((clickPosition - transform.position).normalized * power, ForceMode2D.Impulse);
        }
    }
}
