using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class StringSetter : ClipboardScreen
{
    [Header("References")]
    public TextMeshProUGUI TitleLabel;
    public TMP_InputField InputField;
    public Button DoneButton;
    private string _existingValue;
    private bool _allowEmpty;
    private Action<string> _callback;
    private void Awake();
    public void Initialize(string selectionTitle, string existingValue, int characterLimit, bool allowEmpty, Action<string> callback = null);
    public override void Open();
    public override void Close();
    private void DoneButtonPressed();
    private void OnSubmit(string value);
}