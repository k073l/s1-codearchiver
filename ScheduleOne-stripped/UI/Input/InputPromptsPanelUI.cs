using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.UI.Input;
public class InputPromptsPanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Transform _promptsContainer;
    [SerializeField]
    private InputPromptsItemUI _promptItemPrefab;
    private List<InputPromptsItemUI> _activePrompts;
    private Queue<InputPromptsItemUI> _inactivePrompts;
    public void AddPrompt(string promptLabel, Color promptColor, List<InputPromptsBindingData> bindingDataList, bool isPulsing, List<string> bindingDisplayStrings);
    public void ClearPrompts();
}