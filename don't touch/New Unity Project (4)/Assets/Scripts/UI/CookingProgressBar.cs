using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private float _fillingSpeed;
    [SerializeField] private Color _unfilledColor;
    [SerializeField] private Color _filledColor;

    private float _targetProgress;
    private Color _targetColor;

    public void ResetProgress()
    {
        _targetProgress = 0;
        _targetColor = _unfilledColor;
    }

    public void OnLayerCookingProgresses(float coockingProgress, float neededValue)
    {
        _targetProgress = coockingProgress / neededValue;
        _targetColor = Color.Lerp(_unfilledColor, _filledColor, _targetProgress);
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _targetProgress, _fillingSpeed);
        _fill.color = Color.Lerp(_fill.color, _targetColor, _fillingSpeed);
    }
}
