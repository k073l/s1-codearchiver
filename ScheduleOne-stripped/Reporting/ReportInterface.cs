using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.Platform;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Reporting;
public class ReportInterface : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _titleInput;
    [SerializeField]
    private TMP_InputField _descriptionInput;
    [SerializeField]
    private TMP_Dropdown _reportTypeDropdown;
    [SerializeField]
    private Toggle _includeSaveFileToggle;
    [SerializeField]
    private Toggle _includeScreenshotToggle;
    [SerializeField]
    private Selectable[] _selectablesToTriggerAuthPrep;
    [SerializeField]
    private TextMeshProUGUI _titleRequiredLabel;
    [SerializeField]
    private TextMeshProUGUI _descriptionRequiredLabel;
    [SerializeField]
    private TextMeshProUGUI _typeRequiredLabel;
    [SerializeField]
    private Button _submitButton;
    [SerializeField]
    private RectTransform _inProgressContainer;
    [SerializeField]
    private TextMeshProUGUI _inProgressText;
    [SerializeField]
    private RectTransform _cog;
    [SerializeField]
    private RectTransform _successContainer;
    [SerializeField]
    private RectTransform _errorContainer;
    [SerializeField]
    private TextMeshProUGUI _errorText;
    private void Awake();
    private void OnEnable();
    private void Update();
    private void UpdateInProgressDisplay();
    private void UpdateRequirements();
    private void Submit();
    private void ResetAllInputs();
    private void TypeDropdownChanged(int newValue);
    private bool AreInputsValid();
    private bool CanSubmit();
    private Dictionary<string, string> GetMetadata();
    private ReportTag[] GetTags();
    private string GetOSFamily();
    private string GetNetworkStatus();
    private string GetEnvironment();
}