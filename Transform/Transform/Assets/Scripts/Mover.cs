using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    private bool _isMovigForward;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        CheckPosition();

        if (_isMovigForward)
        {
            MoveForward();
        }
        else
        {
            MoveBackward();
        }
    }

    private void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, _distance), _speed * Time.deltaTime);
    }

    private void MoveBackward()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (transform.position.z == _distance)
        {
            _isMovigForward = false;
        }
        
        if(transform.position == _startPosition)
        {
            _isMovigForward = true;
        }
    }
}
