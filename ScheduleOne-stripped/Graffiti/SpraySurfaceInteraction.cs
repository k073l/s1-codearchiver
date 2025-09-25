using System;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.Levelling;
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
    public const float CAMERA_MOVE_TIME;
    public const int MAX_PIXELS_BEFORE_NEW_STROKE;
    public const int MANHATTAN_DISTANCE_BETWEEN_PAINTED_PIXELS;
    public const int XP_GAIN;
    public const float CARTEL_INFLUENCE_REDUCTION;
    public const int PAINTED_PIXEL_LIMIT;
    public SpraySurface SpraySurface;
    public InteractableObject IntObj;
    public Transform CameraPosition;
    public Canvas Canvas;
    public Image SprayImg;
    public AudioSourceController SpraySound;
    public AudioSourceController CleanSound;
    private ESprayColor selectedColor;
    private UShort2 lastPaintedPixelCoord;
    private bool paintedLastFrame;
    private List<UShort2> currentStrokePixels;
    private bool isPaintingStroke;
    private float timeSinceStrokeStart;
    public bool IsOpen { get; private set; }
    private bool confirmationPanelOpen => ((Component)Singleton<GraffitiMenu>.Instance.ConfirmPanel).gameObject.activeSelf;

    private void Awake();
    private void Start();
    private void PlayerSpawned();
    private void OnDestroy();
    private void OnValidate();
    private void ResizeCanvas();
    private void Update();
    private void UpdateCursor();
    private void FixedUpdate();
    private void StartStroke();
    private void EndStroke(bool stopSpraySound);
    private bool GetCursorPositionOnSurface(out ushort pixelX, out ushort pixelY);
    private Ray GetCursorRay();
    private void Hovered();
    private void Interacted();
    private void UseGraffitiCleaner();
    private void Exit(ExitAction action);
    private void Open();
    private void Close();
    private void Reward();
    private void EquippedSlotChanged(int equippedSlotIndex);
    private void SetColor(ESprayColor color);
    private void Clear();
    private static bool IsSprayCanEquipped();
    private static bool IsGraffitiCleanerEquipped();
}