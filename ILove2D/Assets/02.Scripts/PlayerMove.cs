using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(transform.up, ForceMode2D.Impulse);
        }
    }


}
