using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotater : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, _rotationSpeed * Time.deltaTime);
    }
}
