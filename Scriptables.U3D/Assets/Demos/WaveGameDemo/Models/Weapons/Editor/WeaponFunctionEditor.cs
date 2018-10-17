using UnityEditor;

namespace Demos.WaveGameDemo.Models.Weapons.Editor
{
    [CustomEditor(typeof(WeaponFunction))]
    public class WeaponFunctionEditor : UnityEditor.Editor
    {

        private int _currentLevel = 0;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var weapon = target as WeaponFunction;
            _currentLevel = EditorGUILayout.IntSlider(_currentLevel, 1, weapon.MaxLevel);
            var data = weapon.GetDataForLevel(_currentLevel);

            EditorGUILayout.LabelField("Cooldown", data.Cooldown.ToString());
            EditorGUILayout.LabelField("Max Damage", data.MaxDamage.ToString());
            EditorGUILayout.LabelField("Max Targets", data.MaxTargets.ToString());
            EditorGUILayout.LabelField("Max Damage Per Target", data.MaxDamagePerTarget.ToString());
            EditorGUILayout.LabelField("Damage Radius", data.DamageRadius.ToString());
            EditorGUILayout.LabelField("Velocity", data.Velocity.ToString());
            EditorGUILayout.LabelField("Max DPS", data.MaxDps.ToString());
        }
    }
}
