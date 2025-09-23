using System;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.Networking;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.DevUtilities;
public class Settings : PersistentSingleton<Settings>
{
    public enum UnitType
    {
        Metric,
        Imperial
    }

    public const float MinYPos;
    public const string BETA_ARG;
    public const string DISABLE_COUNTRY_CHECK_ARG;
    public const bool COUNTRY_CHECK;
    public List<string> LaunchArgs;
    public DisplaySettings DisplaySettings;
    public DisplaySettings UnappliedDisplaySettings;
    public GraphicsSettings GraphicsSettings;
    public AudioSettings AudioSettings;
    public InputSettings InputSettings;
    public OtherSettings OtherSettings;
    public InputActionAsset InputActions;
    public GameInput GameInput;
    public ScriptableRendererFeature SSAO;
    public ScriptableRendererFeature GodRays;
    [Header("Camera")]
    public float LookSensitivity;
    public bool InvertMouse;
    public float CameraFOV;
    public InputSettings.EActionMode SprintMode;
    [Range(0f, 1f)]
    public float CameraBobIntensity;
    private InputActionMap playerControls;
    public Action onDisplayChanged;
    public Action onInputsApplied;
    public UnitType unitType { get; protected set; }
    public bool PausingFreezesTime { get; }

    protected override void Awake();
    protected override void Start();
    private void CheckCountryCode();
    public void ApplyDisplaySettings(DisplaySettings settings);
    private void MoveMainWindowTo(DisplayInfo displayInfo);
    public void ReloadGraphicsSettings();
    public void ApplyGraphicsSettings(GraphicsSettings settings);
    public void ReloadAudioSettings();
    public void ApplyAudioSettings(AudioSettings settings);
    public void ReloadInputSettings();
    public void ApplyInputSettings(InputSettings settings);
    public void ReloadOtherSettings();
    public void ApplyOtherSettings(OtherSettings settings);
    public void WriteDisplaySettings(DisplaySettings settings);
    public DisplaySettings ReadDisplaySettings();
    public void WriteGraphicsSettings(GraphicsSettings settings);
    public GraphicsSettings ReadGraphicsSettings();
    public void WriteAudioSettings(AudioSettings settings);
    public AudioSettings ReadAudioSettings();
    public void WriteInputSettings(InputSettings settings);
    public InputSettings ReadInputSettings();
    public void WriteOtherSettings(OtherSettings settings);
    public OtherSettings ReadOtherSettings();
    public string GetActionControlPath(string actionName);
}