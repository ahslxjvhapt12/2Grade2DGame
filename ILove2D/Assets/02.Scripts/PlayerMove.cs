using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _raycastDistance;

    private bool _isJumping = false;
    private bool _canJump = false;

    private Rigidbody2D _rigid;
    Animator _animator;

    [SerializeField] private Transform _rayPos;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        Debug.Log(_animator);
    }

    private void Update()
    {
        Move();
        Attack();
        StartCoroutine(Jump());
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (h < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += new Vector3(h, 0) * Time.deltaTime * _speed;
    }

    private IEnumerator Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_isJumping == true) yield break;

            _canJump = Physics2D.Raycast(_rayPos.position, -transform.up, _raycastDistance, 1 << 6); // Ground layer
            if (_canJump)
            {
                _isJumping = true;
                _rigid.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.075f);
                _isJumping = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_rayPos.position, -transform.up * _raycastDistance);
    }
}
