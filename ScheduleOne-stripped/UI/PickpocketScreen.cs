using System.Collections;
using System.Linq;
using FluffyUnderware.DevTools.Extensions;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.State;
using ScheduleOne.UI.Items;
using ScheduleOne.Vision;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class PickpocketScreen : Singleton<PickpocketScreen>
{
    private enum EActionButtonState
    {
        Hidden,
        StopArrow,
        Continue
    }

    public const int PICKPOCKET_XP;
    [Header("Settings")]
    public float GreenAreaMaxWidth;
    public float GreenAreaMinWidth;
    public float SlideTime;
    public float SlideTimeMaxMultiplier;
    public float ValueDivisor;
    public float Tolerance;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public ItemSlotUI[] Slots;
    public RectTransform[] GreenAreas;
    public Animation TutorialAnimation;
    public RectTransform TutorialContainer;
    public RectTransform SliderContainer;
    public Slider Slider;
    public RectTransform ActionsContainer;
    public MonoState State;
    public UIScreen Screen;
    public UIPanel Panel;
    public GameObject ActionButtonContainer;
    public Button ActionButton;
    public TextMeshProUGUI ActionButtonLabel;
    [Header("Input")]
    public InputActionReference StopPickpocketAction;
    public UnityEvent onFail;
    public UnityEvent onStop;
    public UnityEvent onHitGreen;
    private NPC npc;
    private bool isSliding;
    private int slideDirection;
    private float sliderPosition;
    private float slideTimeMultiplier;
    private bool isFail;
    public bool IsOpen { get; private set; }
    public bool TutorialOpen { get; private set; }

    protected override void Awake();
    protected override void Start();
    public void Open(NPC _npc);
    private void Update();
    private void StartSliding();
    private void StopArrow();
    public void SetSlotLocked(int index, bool locked);
    private bool AreAllSlotsUnlocked();
    private ItemSlotUI GetHoveredSlot();
    private void Fail();
    public void Close();
    private void OnClose();
    private void OpenTutorial();
    public void CloseTutorial();
    private float GetGreenAreaNormalizedPosition(int index);
    private float GetGreenAreaNormalizedWidth(int index);
    private void SetActionButtonState(EActionButtonState state);
    private void ActionButtonClicked();
}