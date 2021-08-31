using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationAxisZ;
    [SerializeField] private float _minRotationAxisZ;

    private bool IsPressedSpaceKey => Input.GetKey(KeyCode.Space);
    private Rigidbody2D _rigidBird;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;


    public void ResetBirdToStart()
    {
        SetForce(Vector2.zero);
        StartPosition();
        StartRotation();
        SetRotation(Quaternion.identity);
    }

    private void Jump()
    {
        if (IsPressedSpaceKey)
        {
            SetForce(new Vector2(_speed, 0));
            SetRotation(_maxRotation);
            _rigidBird.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        SetRotation(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    private void StartPosition()
    {
        transform.position = _startPosition;
    }
    private void StartRotation()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationAxisZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationAxisZ);
    }
    private void SetRotation(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }
    private void SetRotation(Quaternion current, Quaternion target, float time)
    {
        transform.rotation = Quaternion.Lerp(current, target, time);
    }
    private void SetForce(Vector2 force)
    {
        _rigidBird.velocity = force;
    }


    private void Start()
    {
        _rigidBird = GetComponent<Rigidbody2D>();
        ResetBirdToStart();
    }

    private void Update()
    {
        Jump();
    }
}
