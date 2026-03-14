using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI.Input;
public class InputPrompt : MonoBehaviour
{
    public enum EInputPromptAlignment
    {
        Left,
        Middle,
        Right
    }

    public static float Spacing;
    [Header("Settings")]
    public List<InputActionReference> Actions;
    public string Label;
    public EInputPromptAlignment Alignment;
    [Header("References")]
    public RectTransform Container;
    public RectTransform ImagesContainer;
    public TextMeshProUGUI LabelComponent;
    public RectTransform Shade;
    [Header("Settings")]
    public bool OverridePromptImageColor;
    public Color PromptImageColor;
    [SerializeField]
    private List<PromptImage> promptImages;
    private List<InputActionReference> displayedActions;
    private EInputPromptAlignment AppliedAlignment;
    private InputPromptsManager manager { get; }

    private void OnEnable();
    private void OnDisable();
    private void RefreshPromptImages();
    public void SetLabel(string label);
    private void UpdateShade();
}