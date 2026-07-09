using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.UI.Input;
public class InputPromptsUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Transform _promptsCenterContainer;
    [SerializeField]
    private Transform _promptsBottomLeftInGameContainer;
    [SerializeField]
    private Transform _promptsBottomLeftMenuContainer;
    [SerializeField]
    private Transform _promptsCustomContainer;
    [SerializeField]
    private InputPromptsPanelUI _promptItemPrefab;
    private Dictionary<string, InputPromptsPanelUI> _activePrompts;
    private Queue<InputPromptsPanelUI> _inactivePrompts;
    public RectTransform RectTransform => _rectTransform;

    private void Start();
    public bool AddPanel(string id, EInputPromptPosition position);
    public bool AddPanel(string id, Vector3 position, int canvasSortingOrder);
    public void AddPrompt(string panelId, string promptLabel, Color promptColor, List<InputPromptsBindingData> bindingDataList, bool isPulsing, List<string> bindingDisplayStrings);
    public void ClearPanel(string id);
    public void RemovePanel(string id);
    public void ShowHidePanel(string id, bool show);
    private Transform GetPromptsContainer(EInputPromptPosition position);
    private int GetCanvasSorting(EInputPromptPosition position);
    public bool HasActivePrompts();
}