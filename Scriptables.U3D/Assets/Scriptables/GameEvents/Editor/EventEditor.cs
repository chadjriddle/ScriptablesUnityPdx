using Scriptables.GameEvents;
using UnityEditor;
using UnityEngine;

namespace Assets.Scriptables.GameEvents.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as GameEvent;
            if (GUILayout.Button("Raise") && e != null)
            {
                e.Raise();
            }
        }
    }
}