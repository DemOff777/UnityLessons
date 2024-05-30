using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, _rotateSpeed * Time.deltaTime);
    }
}
