using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class LightEventController : MonoBehaviour
{
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Material _onMaterial;

    private bool _isOn;
    private Renderer _renderer;

	// Use this for initialization
	void Start ()
	{
	    _renderer = GetComponent<Renderer>();
	    _renderer.material = _offMaterial;
	    _isOn = false;
	}

    public void Toggle()
    {
        _isOn = !_isOn;
        _renderer.material = _isOn ? _onMaterial : _offMaterial;
    }
}
