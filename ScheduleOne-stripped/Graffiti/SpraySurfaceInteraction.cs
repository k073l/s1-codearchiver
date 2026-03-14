using System;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Compass;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Graffiti;
[RequireComponent(typeof(SpraySurface))]
public class SpraySurfaceInteraction : MonoBehaviour
{
    private const float CameraLerpTime;
    private const int MaxPixelsBeforeNewStroke;
    private const int ManhattanDistanceBetweenPaintedPixels;
    private const int FixedPaintedPixelLimit;
    private const int CanvasPadding;
    public SpraySurface SpraySurface;
    public InteractableObject IntObj;
    public Transform CameraPosition;
    public Canvas Canvas;
    public Image SprayImg;
    public AudioSourceController SpraySound;
    public AudioSourceController CleanSound;
    public bool _allowDraw;
    [Header("Settings")]
    [SerializeField]
    public float PaintedPixelLimitMultiplier;
    private ESprayColor selectedColor;
    private byte selectedStrokeSize;
    private UShort2 lastPaintedPixelCoord;
    private bool paintedLastFrame;
    private List<UShort2> currentStrokePixels;
    private bool isPaintingStroke;
    private float timeSinceStrokeStart;
    private int _startPaintedPixelCount;
    public bool IsOpen { get; private set; }
    private bool confirmationPanelOpen => ((Component)Singleton<GraffitiMenu>.Instance.ConfirmPanel).gameObject.activeSelf;
    private int _paintedPixelLimit => Mathf.RoundToInt(25000f * PaintedPixelLimitMultiplier);

    private void Awake();
    private void Start();
    private void PlayerSpawned();
    private void OnDestroy();
    private void ResizeCanvas();
    private void Update();
    private void UpdateCursor();
    private void UpdateSpraySound();
    private void CheckCameraInBounds();
    private void FixedUpdate();
    private void StartStroke(bool recordHistory = true);
    private void EndStroke(bool stopSpraySound);
    private bool GetCursorPositionOnSurface(out ushort pixelX, out ushort pixelY);
    private Ray GetCursorRay();
    private void Hovered();
    private void Interacted();
    private void UseGraffitiCleaner();
    private void Exit(ExitAction action);
    private void Open();
    private void Close();
    private void EquippedSlotChanged(int equippedSlotIndex);
    private void SetColor(ESprayColor color);
    private void SetStrokeSize(byte strokeSize);
    private void UpdateRemainingPaintIndicator();
    public void Undo();
    private void Clear();
    private static bool IsSprayCanEquipped();
    private static bool IsGraffitiCleanerEquipped();
}