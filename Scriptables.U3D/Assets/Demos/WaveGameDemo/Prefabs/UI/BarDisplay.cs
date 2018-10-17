using System;
using System.Globalization;
using Scriptables.References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Demos.WaveGameDemo.Prefabs.UI
{
    public class BarDisplay : MonoBehaviour {

        public Color borderColor = Color.black;
        public Color fillColor = Color.red;
        public Color titleColor = Color.white;
        public Color currentValueColor = Color.white;

        public string title = String.Empty;

        public bool showCurrentValue = true;

        public bool fillFromRight = true;

        public bool showAsPercent = false;
        public int numberOfDecimals = 0;

        public FloatReference maxValue;
        public FloatReference currentValue;
        public float currentPercent;

        public Image borderImage;
        public Image fillImage;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI currentValueText;

        // Use this for initialization
        void Start () {
            UpdateAllProperties();
        }
	
        // Update is called once per frame
        void Update () {
            UpdateAllProperties();
        }

        void OnValidate()
        {
            UpdateAllProperties();  
        }

        private void UpdateAllProperties()
        {
            borderImage.color = borderColor;
            fillImage.color = fillColor;
            titleText.text = title;
            titleText.color = titleColor;

            currentPercent = currentValue / maxValue;

            fillImage.fillAmount = currentPercent;
            fillImage.fillOrigin = fillFromRight ? 1 : 0;

            if (showCurrentValue)
            {
                var numberFormatInfo = NumberFormatInfo.CurrentInfo.Clone() as NumberFormatInfo;
                numberFormatInfo.NumberDecimalDigits = numberOfDecimals;

                currentValueText.text = showAsPercent
                    ? string.Format(numberFormatInfo, "{0:F}%", Math.Round(currentPercent * 100, numberOfDecimals))
                    : string.Format(numberFormatInfo, "{0:F}", Math.Round(currentValue, numberOfDecimals));

                currentValueText.color = currentValueColor;
            }
            else
            {
                currentValueText.text = string.Empty;
            }
        }
    }
}
