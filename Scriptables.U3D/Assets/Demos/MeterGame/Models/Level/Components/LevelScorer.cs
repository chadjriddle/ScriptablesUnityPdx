using Demos.MeterGame.Models.Level.Scriptables;
using Demos.MeterGame.Models.Level.Scriptables.Generated;
using Scriptables.References;
using UnityEngine;

public class LevelScorer : MonoBehaviour
{
    [SerializeField] private FloatReference _currentPercent;
    [SerializeField] private FloatReference _goodPercent;
    [SerializeField] private FloatReference _perfectPercent;
    [SerializeField] private FloatReference _graceAmount;
    [SerializeField] private LevelCompleteStateVariable _levelCompleteValue;

    [SerializeField] private LevelCompleteStateGameEvent _levelCompleteEvent;

    [SerializeField] private LevelCompleteState _tooLate;
    [SerializeField] private LevelCompleteState _perfect;
    [SerializeField] private LevelCompleteState _good;
    [SerializeField] private LevelCompleteState _tooSoon;


    public void LevelComplete()
    {
        if (_currentPercent > _perfectPercent + _graceAmount)
        {
            _levelCompleteValue.SetValue(_tooLate);
        }
        else if (_currentPercent < _goodPercent)
        {
            _levelCompleteValue.SetValue(_tooSoon);
        }
        else if (_currentPercent > _perfectPercent - _graceAmount)
        {
            _levelCompleteValue.SetValue(_perfect);
        }
        else
        {
            _levelCompleteValue.SetValue(_good);
        }

        _levelCompleteEvent.Raise(_levelCompleteValue);

    }
}
