using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Platform;
public class PlatformConditionalActive : MonoBehaviour
{
    public enum EMode
    {
        ActiveWhenConditionMet,
        InactiveWhenConditionMet
    }

    public enum EEvaluationMode
    {
        Any,
        All
    }

    public enum EConditions
    {
        IsWindows,
        IsLinux,
        IsConsole,
        IsKeyboardMouse,
        IsGamepad
    }

    [SerializeField]
    private List<GameObject> _targetObjects;
    [Header("Settings")]
    [SerializeField]
    private EMode _mode;
    [SerializeField]
    private EEvaluationMode _evaluationMode;
    [SerializeField]
    private List<EConditions> _conditions;
    private void Awake();
    private void OnDestroy();
    private void OnEnable();
    private void InputDeviceChanged(GameInput.InputDeviceType newInputDevice);
    private void EvaluateConditions();
    public static bool EvaluateCondition(EConditions condition);
}