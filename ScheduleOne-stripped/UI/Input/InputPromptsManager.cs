using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;

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
    public PromptImage GetPromptImage(string controlPath, RectTransform parent);
    private bool IsControlPathMouseRelated(string controlPath);
    private bool IsControlPathWideKey(string controlPath);
    private bool IsControlPathExtraWideKey(string controlPath);
    public string GetDisplayNameForControlPath(string controlPath);
}