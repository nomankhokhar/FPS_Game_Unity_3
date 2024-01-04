using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timer;
    private float _elapsedTime;
    private const int _activeTimeInSeconds = 16;

    public void Reset()
    {
        _timer.text = "0";
        _elapsedTime = _activeTimeInSeconds;
    }

    private void Awake()
    {
        _timer = GetComponent<Text>();
    }
    
    private void OnDisable()
    {
        _timer.text = "0";
        _elapsedTime = 0;
    }

    private void Update()
    {
        if (_elapsedTime <= 0)
        {
            _timer.enabled = false;
            return;
        }

        _elapsedTime -= Time.deltaTime;
        _timer.text = ((int)_elapsedTime).ToString();
    }
}
