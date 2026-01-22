using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Graffiti;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class GraffitiMenu : Singleton<GraffitiMenu>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform ColorButtonContainer;
    public Button ClearButton;
    public Button DoneButton;
    public Transform ConfirmPanel;
    public Button ConfirmButton;
    public Button CancelButton;
    public Button UndoButton;
    public RectTransform RemainigPaintContainer;
    public Slider RemainingPaintSlider;
    public Image[] RemainingPaintImages;
    public TextMeshProUGUI RemainingPaintLabel;
    public Button[] WeightButtons;
    [Header("Prefabs")]
    public GameObject ColorButtonPrefab;
    public Action<ESprayColor> onColorSelected;
    public Action<byte> onWeightSelected;
    public Action onClearClicked;
    public Action onDone;
    public Action onUndoClicked;
    private List<Button> colorButtons;
    private SpraySurface activeSurface;
    protected override void Awake();
    public void Open();
    public void Close();
    private void Update();
    public void ShowConfirmPanel();
    private void SelectColor(ESprayColor color);
    private void WeightButtonClicked(int buttonIndex);
    public void UpdateRemainingPaintIndicator(float remainingPaint);
    private void ClearClicked();
    private void UndoClicked();
    private void Done();
    private void CancelClicked();
    public void SetActiveSurface(SpraySurface surface);
    public void ClearActiveSurface();
    private void UpdateUndoInteraction();
}