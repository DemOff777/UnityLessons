using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeTransformer : MonoBehaviour
{
    [SerializeField] private Transform _cube;
    [SerializeField] private float _scaleIndex;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;

    private Vector3 _startScale;
    private Vector3 _newScale;
    private bool _isScaling;
    private bool _isBackScaling;

    private void Start()
    {
        _isScaling = false;
        _isBackScaling = false;
        _startScale = _cube.localScale;
        _newScale = new Vector3(_cube.localScale.x * _scaleIndex, _cube.localScale.y * _scaleIndex, _cube.localScale.z * _scaleIndex);
    }

    private void Update()
    {
        if (transform.localScale == _startScale)
        {
            _isScaling = true;
        }

        if (_isScaling)
        {
            Scale();
        }

        if (transform.localScale == _newScale)
        {
            _isBackScaling = true;
        }

        if (_isBackScaling)
        {
            BackScale();
        }

        Rotate();
        Move();
    }

    private void Scale()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _newScale, _scaleSpeed * Time.deltaTime);
        _isBackScaling = false;
    }

    private void BackScale()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _startScale, _scaleSpeed * Time.deltaTime);
        _isScaling = false;
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, transform.up, _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {        
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
