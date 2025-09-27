using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class PlayerEnergyUI : Singleton<PlayerEnergyUI>
{
    public Slider Slider;
    public RectTransform SliderRect;
    public Image FillImage;
    public TextMeshProUGUI Label;
    [Header("Settings")]
    public Color SliderColor_Green;
    public Color SliderColor_Red;
    private float displayedValue;
    protected override void Awake();
    private void UpdateDisplayedEnergy();
    public void SetDisplayedEnergy(float energy);
    protected virtual void Update();
}