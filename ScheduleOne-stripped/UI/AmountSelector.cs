using System;
using ScheduleOne.GamepadInput;
using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class AmountSelector : MonoBehaviour
{
    [Header("Settings")]
    public float MinValue;
    public float MaxValue;
    [Header("References")]
    [SerializeField]
    private InputField _inputField;
    [SerializeField]
    private TMP_InputField _tmpInputField;
    [SerializeField]
    private InputValueRamp _ramp;
    public float SelectedAmount { get; private set; }

    public event Action<float> OnAmountChanged;
    private void Awake();
    private void InputFieldSubmitted(string value);
    public void ChangeAmount(float change);
    public void SetAmount(float amount);
}