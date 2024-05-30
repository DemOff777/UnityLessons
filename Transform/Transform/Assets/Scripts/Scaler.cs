using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleIndex;
    [SerializeField] private float _speed;

    private bool _isScaling;

    private Vector3 _startScale;
    private Vector3 _indexScale;

    private void Start()
    {
        _startScale = transform.localScale;
        _indexScale = new Vector3(transform.localScale.x * _scaleIndex, transform.localScale.y * _scaleIndex, transform.localScale.z * _scaleIndex);
    }

    private void Update()
    {
        CheckPosition();

        if (_isScaling)
        {
            Scaling(_indexScale);
        }
        else
        {
            Scaling(_startScale);
        }
    }

    private void Scaling(Vector3 scale)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, scale, _speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (transform.localScale == _indexScale)
        {
            _isScaling = false;
        }

        if (transform.localScale == _startScale)
        {
            _isScaling = true;
        }
    }
}
