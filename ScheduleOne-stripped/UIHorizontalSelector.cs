using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIHorizontalSelector : UIOption
{
    [SerializeField]
    private Button prevButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private TextMeshProUGUI currentOptionNameText;
    public UnityEvent<OptionInfo> OnChanged;
    private List<OptionInfo> options;
    private int currentIndex;
    protected override float NavigationRepeatRateMult => 2f;

    protected override void Awake();
    protected override void OnUpdate();
    protected override void MoveLeft();
    protected override void MoveRight();
    private void MovePrev();
    private void MoveNext();
    private void UpdateCurrentOptionText();
    public void SetOptions(List<OptionInfo> newOptions, int defaultIndex = 0);
}