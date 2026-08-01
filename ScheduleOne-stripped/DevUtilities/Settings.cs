using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.Core.Audio;
using ScheduleOne.Gamepad;
using ScheduleOne.Networking;
using ScheduleOne.Platform;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.DevUtilities;
public class Settings : PersistentSingleton<Settings>
{
    public enum EUnitType
    {
        Metric,
        Imperial
    }

    public const float MinYPos;
    public const string BETA_ARG;
    public List<string> LaunchArgs;
    public DisplaySettings DisplaySettings;
    public DisplaySettings UnappliedDisplaySettings;
    public GraphicsSettings GraphicsSettings;
    public AudioSettings AudioSettings;
    public InputSettings InputSettings;
    public GamepadSettings GamepadSettings;
    public OtherSettings OtherSettings;
    public InputActionAsset InputActions;
    public GameInput GameInput;
    public ScriptableRendererFeature SSAO;
    public ScriptableRendererFeature GodRays;
    [Header("Platform Default Settings")]
    [SerializeField]
    private List<PlatformDefaultSettings> _platformDefaultSettingsList;
    [Header("Camera")]
    public bool InvertMouse;
    public float CameraFOV;
    public InputSettings.EActionMode SprintMode;
    [Range(0f, 1f)]
    public float CameraBobIntensity;
    [Header("Bindings")]
    [SerializeField]
    private List<InputActionReference> _gamepadRebindings;
    [SerializeField]
    private List<InputActionReference> _pcRebindings;
    private InputActionMap playerControls;
    public Action onInputsApplied;
    public Action onUnappliedDisplayIndexChanged;
    private PlatformDefaultSettings _thisPlatformDefaultSettings;
    private float mouseCameraSensitivity;
    private float gamepadCameraSensitivity;
    private string _defaultBindingOverrides;
    public static bool ChristmasEventActive { get; private set; }
    public bool PausingFreezesTime { get; }
    public EUnitType UnitType { get; private set; }
    public float LookSensitivity { get; }
    public List<InputActionReference> GamepadRebindings => _gamepadRebindings;
    public List<InputActionReference> PCRebindings => _pcRebindings;

    public event Action onDisplaySettingsApplied;
    public event Action onQualitySettingsChanged;
    protected override void Awake();
    protected override void Start();
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
    public void ReloadGamepadSettings();
    public void ApplyGamepadSettings(GamepadSettings settings);
    public void RestoreDefaultKeyboardBindings();
    public void RestoreDefaultGamepadBindings();
    public void WriteDisplaySettings(DisplaySettings settings);
    public DisplaySettings ReadDisplaySettings();
    public void WriteGraphicsSettings(GraphicsSettings settings);
    public GraphicsSettings ReadGraphicsSettings();
    public void WriteAudioSettings(AudioSettings settings);
    public AudioSettings ReadAudioSettings();
    public void WriteGamepadSettings(GamepadSettings settings);
    public GamepadSettings ReadGamepadSettings();
    public void WriteInputSettings(InputSettings settings);
    public InputSettings ReadInputSettings();
    public void WriteOtherSettings(OtherSettings settings);
    public OtherSettings ReadOtherSettings();
    public string GetActionControlPath(string actionName);
    private EUnitType GetDefaultUnitTypeForPlayer();
}