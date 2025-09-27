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
    public Transform ConfirmPanel;
    public Button ConfirmButton;
    public Button CancelButton;
    public RectTransform RemainigPaintContainer;
    public Slider RemainingPaintSlider;
    public Image[] RemainingPaintImages;
    public TextMeshProUGUI RemainingPaintLabel;
    [Header("Prefabs")]
    public GameObject ColorButtonPrefab;
    public Action<ESprayColor> onColorSelected;
    public Action onClearClicked;
    public Action onConfirmClicked;
    private List<Button> colorButtons;
    private SpraySurface activeSurface;
    protected override void Awake();
    public void Open();
    public void Close();
    public void ShowConfirmPanel();
    private void SelectColor(ESprayColor color);
    public void UpdateRemainingPaintIndicator(float remainingPaint);
    private void ClearClicked();
    private void ConfirmClicked();
    private void CancelClicked();
}