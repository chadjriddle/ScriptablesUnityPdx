using Demos.MeterGame.Models.Level.Scriptables;
using Scriptables.References;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] private FloatReference _perfectPercent;
    [SerializeField] private FloatReference _goodPercent;
    [SerializeField] private FloatReference _allowedSeconds;

    private LevelCompleteState _lastLevelCompleteState;

    [SerializeField] private LevelCompleteState _tooLate;
    [SerializeField] private LevelCompleteState _perfect;
    [SerializeField] private LevelCompleteState _good;
    [SerializeField] private LevelCompleteState _tooSoon;

    public void LevelCompleted(LevelCompleteState levelCompleteState)
    {
        _lastLevelCompleteState = levelCompleteState;
    }

    public void NextLevel()
    {
        if (_lastLevelCompleteState == _tooLate) 
        {
            // Do Nothing
        }
        else if (_lastLevelCompleteState == _tooSoon)
        {
            // Do Nothing
        }
        else if (_lastLevelCompleteState == _good)
        {
            var currentGap = _perfectPercent - _goodPercent;
            
            _perfectPercent.SetValue(Random.Range(0.75f, 0.95f));
            _goodPercent.SetValue(_perfectPercent - (currentGap * Random.Range(0.8f, 0.95f)));
            _allowedSeconds.SetValue(_allowedSeconds * Random.Range(0.92f, 0.98f));
        }
        else
        {
            var currentGap = _perfectPercent - _goodPercent;

            _perfectPercent.SetValue(Random.Range(0.60f, 0.95f));
            _goodPercent.SetValue(_perfectPercent - (currentGap * Random.Range(0.75f, 0.9f)));
            _allowedSeconds.SetValue(_allowedSeconds * Random.Range(0.88f, 0.94f));
        }
    }

}
