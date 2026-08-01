using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Input;
public class InputPromptsItemUI : MonoBehaviour
{
    [Serializable]
    public class PromptImage
    {
        public Image Image;
        public Image Backdrop;
        public LayoutElement Layout;
        public TextMeshProUGUI Label;
    }

    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI _promptLabel;
    [SerializeField]
    private List<PromptImage> _promptImages;
    [Header("Pulse Animation")]
    [SerializeField]
    private float _pulseDimDuration;
    [SerializeField]
    private float _pulseBrightDuration;
    [SerializeField]
    private float _pulseDimMultiplier;
    private bool _isPulsing;
    private float _animElapsedTime;
    private List<Color> _promptAnimColors;
    public void Update();
    public void Set(string promptLabel, Color promptColor, List<InputPromptsBindingData> bindingDataList, bool isPulsing, List<string> bindingDisplayStrings);
    public void ResetPrompt();
    private void HandlePulseAnimation();
}