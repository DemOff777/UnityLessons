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
        if (Input.GetMouseButtonDown(0))
        {
            _isWorking = !_isWorking;
        }
    }

    private IEnumerator CountDown()
    {      
        var wait = new WaitForSeconds(_delay);

        for (int i = _start; i >= 0; i++)
        {
            if (_isWorking == false)
            {
                var waitForClick = new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return waitForClick;
            }

            DisplayCountdown(i);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
