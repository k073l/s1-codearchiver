using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ScheduleOne.UI.Input;
public class InputPromptsManager : Singleton<InputPromptsManager>
{
    [Header("Input Prompt Prefabs")]
    public GameObject KeyPromptPrefab;
    public GameObject WideKeyPromptPrefab;
    public GameObject ExtraWideKeyPromptPrefab;
    public GameObject LeftClickPromptPrefab;
    public GameObject MiddleClickPromptPrefab;
    public GameObject RightClickPromptPrefab;
    [Header("UI")]
    [SerializeField]
    private InputPromptsUI _inputPromptsUI;
    [Header("Input Data")]
    [SerializeField]
    private List<InputPromptsData> _inputPromptDataList;
    [Header("Debugging")]
    [SerializeField]
    private string _debugModuleId;
    [SerializeField]
    private bool _debugUseCustomInputType;
    [SerializeField]
    private string _debugInputType;
    [Header("testing")]
    [SerializeField]
    private Vector2 _minAnchor;
    [SerializeField]
    private Vector2 _maxAnchor;
    [SerializeField]
    private Vector2 _pivot;
    [SerializeField]
    private Vector2 _position;
    private Dictionary<string, InputPromptsData> _inputDataLookup;
    private Dictionary<string, InputPromptsData> _activePrompts;
    private Dictionary<string, string> _promptTextOverrides;
    private List<InputPromptsBindingData> _bindingDataList;
    private InputPromptReferenceEventHandler _onModuleLoaded;
    private Action<string> _onModuleUnloaded;
    public PromptImage GetPromptImage(string controlPath, RectTransform parent);
    private bool IsControlPathMouseRelated(string controlPath);
    private bool IsControlPathWideKey(string controlPath);
    private bool IsControlPathExtraWideKey(string controlPath);
    public string GetDisplayNameForControlPath(string controlPath);
    protected override void Start();
    protected override void OnDestroy();
    public void LoadModule(string id, EInputPromptPosition position = EInputPromptPosition.BottomLeftInGame, string displayTextOverride = null);
    public void LoadModule(string id);
    public void LoadModule(InputPromptsData inputData, EInputPromptPosition position = EInputPromptPosition.BottomLeftInGame, string displayTextOverride = null);
    public void LoadModule(string id, Vector3 position, int canvasSortingOrder, string displayTextOverride = null);
    public void LoadModule(InputPromptsData inputData, Vector3 position, int canvasSortingOrder, string displayTextOverride = null);
    public void UnloadModule(InputPromptsData inputData);
    public void UnloadModule(string id);
    public InputPromptsBindingData GetBindingDataFromDescriptor(InputPromptsDescriptorData descriptor);
    public List<InputPromptsBindingData> GetAllBindingDataFromDescriptor(InputPromptsDescriptorData descriptor, out List<string> bindingDisplayStrings);
    public InputPromptsBindingData GetBindingDataFromActionReference(InputActionReference actionReference);
    public InputPromptsData GetInputPromptData(string id);
    public void UpdateDisplayTextOverride(string panelId, string displayTextOverride);
    public void ShowHideActivePrompt(string panelId, bool show);
    public bool HasActivePrompt(string id);
    public bool GetInlinePromptLabel(string inlineId, out string label);
    private bool AddInputPrompt(string panelId, InputPromptsDescriptorData descriptor, bool isPulsing, string displayTextOverride = null);
    private void RefreshInputPrompts();
    private List<InputPromptsBindingData> GetPromptBindingsForCurrentControlScheme(InputPromptsDescriptorData descriptor, out List<string> bindingDisplayStrings);
    private bool HasCorrectControlScheme(string effectivePath);
    private bool HasCorrectPlatformType(EPlatformType platformType);
    private string GetControlUsedScheme();
    private void OnInputChange(GameInput.InputDeviceType deviceType);
    public void SubscribeToModuleLoaded(InputPromptReferenceEventHandler callback);
    public void UnsubscribeFromModuleLoaded(InputPromptReferenceEventHandler callback);
    public void SubscribeToModuleUnloaded(Action<string> callback);
    public void UnsubscribeFromModuleUnloaded(Action<string> callback);
    [Button]
    public void DebugLoadModule();
    [Button]
    public void DebugUnloadModule();
}