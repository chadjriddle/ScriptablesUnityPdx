using Scriptables.References;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptables.Components
{
    public class SetFillFromFloat : MonoBehaviour
    {

        [SerializeField] private Image _image;
        [SerializeField] private FloatReference _fillAmount;

        // Update is called once per frame
        void Update () {
            if (_image != null && _fillAmount != null)
            {
                _image.fillAmount = _fillAmount;
            }
        }

        void Reset()
        {
            if (_image == null)
            {
                _image = GetComponent<Image>();
            }
        }
    }

}
