using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueTextController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _valueText;
    [SerializeField] Slider _slider;

    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] float _modifier;
    [Range(0, 3)]
    [SerializeField] int _floatPointsCount;

    public void OnSliderValueChange()
    {
        string floatPoints = "F" + _floatPointsCount.ToString();
        _valueText.text = (_slider.value * _modifier).ToString(floatPoints);
    }
}
