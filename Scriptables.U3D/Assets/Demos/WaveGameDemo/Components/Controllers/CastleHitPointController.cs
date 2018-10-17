using Scriptables.References;
using UnityEngine;

namespace Demos.WaveGameDemo.Components.Controllers
{
    /// <summary>
    /// Responsible for determining max castle Hit Points and hit point recovery
    /// </summary>
    public class CastleHitPointController : MonoBehaviour
    {
        public BoolReference GameRunning;
        public IntReference CastleLevel;
        public FloatReference CastleHP;
        public FloatReference CastleMaxHP;
        public FloatReference CastleHPRatePerSecond;

        void Awake()
        {
            CastleLevel.ValueChanged += SetValuesFromCastleLevel;
        }

        // Use this for initialization
        void Start () {
            SetValuesFromCastleLevel();
        }
	
        // Update is called once per frame
        void Update () {
            if (GameRunning.Value)
            {
                CastleHP.ApplyChange(CastleHPRatePerSecond.Value * Time.deltaTime);
            }
        }

        public void SetValuesFromCastleLevel()
        {
            DetermineAndSetCastleMaxHP();
            DetermineAndSetCastleHPRatePerSecond();
        }

        public void ResetHitPoints()
        {
            CastleHP.Variable.SetRange(0, CastleMaxHP.Value);
            CastleHP.SetValue(CastleMaxHP);
        }

        private void DetermineAndSetCastleMaxHP()
        {
            var max = 100 + Mathf.Pow(CastleLevel.Value, 4);
            CastleMaxHP.SetValue(max);

            CastleHP.Variable.SetRange(0, CastleMaxHP.Value);
            CastleHP.SetValue(CastleMaxHP);
        }

        private void DetermineAndSetCastleHPRatePerSecond()
        {
            var value = CastleLevel;
            CastleHPRatePerSecond.SetValue(value);
        }
    }
}
