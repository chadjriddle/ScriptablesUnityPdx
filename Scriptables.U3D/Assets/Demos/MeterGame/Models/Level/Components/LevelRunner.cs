using Scriptables.GameEvents;
using Scriptables.References;
using UnityEngine;

public class LevelRunner : MonoBehaviour
{

    [SerializeField] private BoolReference _isLevelRunning;
    [SerializeField] private BoolReference _isActionHeld;

    [SerializeField] private GameEvent _startLevelEvent;
    [SerializeField] private GameEvent _stopLevelEvent;


    // Use this for initialization
    void Start()
    {
        _isActionHeld.ValueChanged += MainActionPressedHandler;
    }

    private void MainActionPressedHandler()
    {
        if (_isActionHeld == true)
        {
            StartMeter();
        }
        else
        {
            StopMeter();
        }
    }

    public void StartMeter()
    {
        _isLevelRunning.SetValue(true);
        _startLevelEvent.Raise();
    }

    private void StopMeter()
    {
        _isLevelRunning.SetValue(false);
        _stopLevelEvent.Raise();
    }
}
