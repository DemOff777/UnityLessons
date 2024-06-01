using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private float _delay;
    [SerializeField] private int _start;

    private IEnumerator _countdown;
    private bool _isWorking = true;

    private void Start()
    {
        _text.text = string.Empty;
        _countdown = CountDown();
        StartCoroutine(_countdown);
    }

    private void Update()
    {
        if (_isWorking && Input.GetMouseButtonDown(0))
        {
            StopCoroutine(_countdown);
        }

        if (_isWorking == false && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_countdown);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(_isWorking)
            {
                _isWorking = false;
            }
            else
            {
                _isWorking = true;
            }
        }
    }

    private IEnumerator CountDown()
    {      
        var wait = new WaitForSeconds(_delay);

        for (int i = _start; i >= 0; i++)
        {
            DisplayCountdown(i);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
