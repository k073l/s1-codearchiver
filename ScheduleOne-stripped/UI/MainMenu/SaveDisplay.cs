using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
public class SaveDisplay : MonoBehaviour
{
    [Header("References")]
    public RectTransform[] Slots;
    public void Awake();
    public void Refresh();
    public void SetDisplayedSave(int index, SaveInfo info);
    private float RoundToDecimalPlaces(float value, int decimalPlaces);
    public static float ToSingle(double value);
    private string GetTimeLabel(int hours);
}