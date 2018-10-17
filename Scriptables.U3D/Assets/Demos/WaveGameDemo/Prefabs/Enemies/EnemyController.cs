using System;
using System.Collections;
using System.Collections.Generic;
using Demos.WaveGameDemo.Prefabs.Enemies;
using Demos.WaveGameDemo.Prefabs.UI;
using Scriptables.GameEvents;
using Scriptables.Variables;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    public BoolVariable GameRunning;
    public IntGameEvent GoldEarnedEvent;
    public BarDisplay HealthBar;
    public WeaponController Weapon;
    public HealthController HealthController;
    public Transform HeathCanvasTransform;

    private Animator _animator;

    public float CurrentSpeed
    {
        get { return _currentSpeed; }
    }

    public float CurrentHealth
    {
        get { return _currentHealth.Value; }
    }

    private float _currentSpeed;
    private FloatVariable _currentHealth;

    private GameObject _modelGameObject;
    private Action<EnemyController> _deathAction;

    private bool _isDead = true;

    void Update()
    {
        if (!GameRunning || _isDead)
        {
            Weapon.enabled = false;
            return;
        }

        if (_currentSpeed > 0)
        {
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime, Space.World);
        }

        _animator?.SetFloat("Speed", _currentSpeed);

        if (_currentHealth.Value <= 0)
        {
            _isDead = true;
            _currentSpeed = 0;
            _animator?.SetTrigger("Death");
            GoldEarnedEvent?.Raise(_enemyData.GoldReward);
            Destroy(gameObject, 1.0f);
            _deathAction?.Invoke(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Castle"))
        {
            _currentSpeed = 0;
        }
    }

    public void OnValidate()
    {
#if UNITY_EDITOR
        if (isActiveAndEnabled)
        {
            StartCoroutine(InitializeInEditor());
        }
#endif
    }

    public void Initialize(EnemyData data, Action<EnemyController> deathAction)
    {
        ClearModel();

        _enemyData = data;
        _deathAction = deathAction;
        _currentSpeed = _enemyData?.Speed ?? _currentSpeed;

        if (_enemyData != null)
        {
            CreateModel();
            InitializeHealth();
            InitializeWeapon();
        }

        _isDead = false;
    }

    private void ClearModel()
    {
        if (_modelGameObject != null)
        {
#if UNITY_EDITOR
            if (isActiveAndEnabled)
            {
                StartCoroutine(Destroy(_modelGameObject));
            }
#else
                Destroy(_modelGameObject);
#endif
        }
    }

#if UNITY_EDITOR
    private IEnumerator InitializeInEditor()
    {
        yield return new WaitForEndOfFrame();
        Initialize(_enemyData, null);
        UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
    }

    private IEnumerator Destroy(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(go);
    }
#endif

    private void CreateModel()
    {
        _modelGameObject = Instantiate(_enemyData.Prefab);
        _modelGameObject.transform.SetParent(transform, false);

        _animator = _modelGameObject.GetComponentInChildren<Animator>();
    }

    private void InitializeHealth()
    {
        _currentHealth = ScriptableObject.CreateInstance<FloatVariable>();
        _currentHealth.SetValue(_enemyData.Health);

        HealthController.Health.Variable = _currentHealth;
        HealthBar.maxValue.ConstantValue = _enemyData.Health;
        HealthBar.currentValue.Variable = _currentHealth;

        var modelExtentsY = _modelGameObject.GetComponentInChildren<Renderer>().bounds.extents.y;
        HeathCanvasTransform.localPosition = new Vector3(0, modelExtentsY * 1.5f, 0);

        HealthController.DamageTaken = () =>
        {
            if (_currentHealth.Value > 0)
            {
                _animator?.SetTrigger("Hit");
            }
        };

    }

    private void InitializeWeapon()
    {
        Weapon.Initialize(_enemyData.Weapon);
        Weapon.Attacking = () => _animator?.SetTrigger("Attack");
    }

}
