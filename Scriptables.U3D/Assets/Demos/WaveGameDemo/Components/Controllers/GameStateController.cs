using Scriptables.Variables;
using UnityEngine;

namespace Demos.WaveGameDemo.Components.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        public BoolVariable GameRunning;

        private void Start()
        {
            GameRunning.SetValue(false);
        }

        public void BeginLevel()
        {
            GameRunning.SetValue(true);
        }

        public void EndLevel()
        {
            GameRunning.SetValue(false);
        }


    }
}
