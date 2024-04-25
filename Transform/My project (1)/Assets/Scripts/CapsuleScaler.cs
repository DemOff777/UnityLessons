using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScaler : MonoBehaviour
{
    [SerializeField] private Transform _capsule;
    [SerializeField] private float _scaleIndex;
    [SerializeField] private float _scaleSpeed;

    private Vector3 _startScale;
    private Vector3 _newScale;
    private bool _isScaling;
    private bool _isBackScaling;

    private void Start()
    {
        _isScaling = false;
        _isBackScaling = false;
        _startScale = _capsule.localScale;
        _newScale = new Vector3(_capsule.localScale.x * _scaleIndex, _capsule.localScale.y * _scaleIndex, _capsule.localScale.z * _scaleIndex);
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
}
