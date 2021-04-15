using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    private float _moveSpeed;
    private float _rotateSpeed;
    private float _rotateTowerSpeed;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _moveSpeed = 8.0f;
        _rotateSpeed = 50.0f;
        _rotateTowerSpeed = 50.0f;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        TurnTower();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = _rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }

    private void TurnTower()
    {
        tower.transform.Rotate(Vector3.up, _rotateTowerSpeed * Input.GetAxis("HorizontalTower") * Time.deltaTime);
    }
}
