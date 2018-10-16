using System.Linq;
using Scriptables.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Scriptables.Variables.Editor
{
    [InitializeOnLoad]
    public class AutoResetManager : MonoBehaviour {

        static AutoResetManager()
        {
            EditorApplication.playModeStateChanged += PlayModeStateChangeHandler;
        }

        private static void PlayModeStateChangeHandler(PlayModeStateChange playModeState)
        {
            if (playModeState == PlayModeStateChange.ExitingEditMode || playModeState == PlayModeStateChange.ExitingPlayMode)
            {
                foreach (var resetable in Resources.FindObjectsOfTypeAll<ScriptableObject>().OfType<IResetable>())
                {
                    resetable.Reset();
                }
            }
        }
    }
}

