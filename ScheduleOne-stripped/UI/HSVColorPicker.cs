using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class HSVColorPicker : MonoBehaviour
{
    [SerializeField]
    private Slider hueSlider;
    [SerializeField]
    private Slider saturationSlider;
    [SerializeField]
    private Slider valueSlider;
    [SerializeField]
    private Image saturationImg;
    [SerializeField]
    private Image valueImg;
    public Color Color => GetOutput();

    public event Action<Color> OnColorChanged;
    private void Awake();
    public void SetColor(Color color);
    private void HueChanged(float value);
    private void SaturationChanged(float value);
    private void ValueChanged(float value);
    private void RefreshImages();
    private Color GetOutput();
}