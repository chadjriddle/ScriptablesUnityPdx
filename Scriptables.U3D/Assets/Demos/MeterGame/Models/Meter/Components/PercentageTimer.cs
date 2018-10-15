using Scriptables.GameEvents;
using Scriptables.References;
using UnityEngine;

/// <summary>
/// Calculate the percent used of the provided number of seconds and raise an event if/when the time runs out
/// </summary>
public class PercentageTimer : MonoBehaviour {

    [SerializeField] private FloatReference _secondsToRun;
    [SerializeField] private FloatReference _currentPercentUsed;
    [SerializeField] private GameEvent _timerExpiredEvent;

    private float _timeRemaining;
    private bool _isRunning;

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
        {
            _timeRemaining -= Time.deltaTime;
            UpdateCurrentPercentUsed();

            if (_timeRemaining < 0)
            {
                StopTimer();
                _timerExpiredEvent?.Raise();
            }
        }
    }

    private void UpdateCurrentPercentUsed()
    {
        _currentPercentUsed.SetValue((_secondsToRun - _timeRemaining) / _secondsToRun);
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void StartTimer()
    {
        ResetTimer();
        _isRunning = true;
    }

    public void ResetTimer()
    {
        _timeRemaining = _secondsToRun;
        UpdateCurrentPercentUsed();
    }
}
