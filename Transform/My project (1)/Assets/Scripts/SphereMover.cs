using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] Transform _sphere;
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveSpeed;

    private Vector3 _newPosition;
    private Vector3 _startPosition;
    private bool _isMoving = false;
    private bool _isMovingBack = false;

    private void Start()
    {
        _startPosition = _sphere.position;
        _newPosition = new Vector3(_sphere.position.x, _sphere.position.y, _moveDistance);
    }

    private void Update()
    {
        if (transform.position == _startPosition)
        {
            _isMoving = true;
        }

        if (_isMoving)
        {
            Move();
        }

        if (transform.position == _newPosition)
        {
            _isMovingBack = true;
        }

        if (_isMovingBack)
        {
            MoveBack();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _newPosition, _moveSpeed * Time.deltaTime);
        _isMovingBack = false;
    }

    private void MoveBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, _moveSpeed * Time.deltaTime);
        _isMoving = false;
    }
}
