using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;
    [SerializeField] private float _scaleIndex;
    [SerializeField] private float _speed;

    private bool _isScaling;

    private Vector3 _startPosition;
    private Vector3 _scalingPosition;

    private void Start()
    {
        _startPosition = transform.localScale;
        _scalingPosition = new Vector3(transform.localScale.x * _scaleIndex, transform.localScale.y * _scaleIndex, transform.localScale.z * _scaleIndex);
    }


    private void Update()
    {
        Move();
        Rotate();

        CheckPosition();

        if (_isScaling)
        {
            Scaling();
        }
        else
        {
            ScalingBack();
        }
    }

    private void Move()
    {;
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, transform.up, _rotateSpeed * Time.deltaTime);
    }

    private void Scaling()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _scalingPosition, _speed * Time.deltaTime);
    }

    private void ScalingBack()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _startPosition, _speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (transform.localScale == _scalingPosition)
        {
            _isScaling = false;
        }

        if (transform.localScale == _startPosition)
        {
            _isScaling = true;
        }
    }
}
