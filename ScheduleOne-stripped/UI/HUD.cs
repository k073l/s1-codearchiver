using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Law;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class HUD : Singleton<HUD>
{
    [Header("References")]
    public Canvas canvas;
    public RectTransform canvasRect;
    public Image crosshair;
    [SerializeField]
    protected Image blackOverlay;
    [SerializeField]
    protected Image radialIndicator;
    [SerializeField]
    protected GraphicRaycaster raycaster;
    [SerializeField]
    protected TextMeshProUGUI topScreenText;
    [SerializeField]
    protected RectTransform topScreenText_Background;
    public Text fpsLabel;
    public RectTransform cashSlotContainer;
    public RectTransform cashSlotUI;
    public RectTransform onlineBalanceContainer;
    public RectTransform onlineBalanceSlotUI;
    public RectTransform managementSlotContainer;
    public ItemSlotUI managementSlotUI;
    public RectTransform HotbarContainer;
    public RectTransform SlotContainer;
    public ItemSlotUI discardSlot;
    public Image discardSlotFill;
    public TextMeshProUGUI selectedItemLabel;
    public RectTransform QuestEntryContainer;
    public TextMeshProUGUI QuestEntryTitle;
    public CrimeStatusUI CrimeStatusUI;
    public BalanceDisplay OnlineBalanceDisplay;
    public BalanceDisplay SafeBalanceDisplay;
    public CrosshairText CrosshairText;
    public RectTransform UnreadMessagesPrompt;
    public TextMeshProUGUI SleepPrompt;
    public TextMeshProUGUI CurfewPrompt;
    public CanvasGroup NotificationsCanvasGroup;
    public Animation CashSlotHintAnim;
    public CanvasGroup CashSlotHintAnimCanvasGroup;
    [SerializeField]
    private ReticleController _reticleController;
    [Header("Settings")]
    public Gradient RedGreenGradient;
    private int SampleSize;
    private List<float> _previousFPS;
    private EventSystem eventSystem;
    private Coroutine blackOverlayFade;
    private bool radialIndicatorSetThisFrame;
    protected override void Awake();
    protected override void Start();
    public void SetCrosshairVisible(bool vis);
    public void SetBlackOverlayVisible(bool vis, float fadeTime);
    private void Update();
    private void UpdateQuestEntryTitle();
    private void RefreshFPS();
    private float GetAverageFPS();
    protected virtual void LateUpdate();
    protected IEnumerator FadeBlackOverlay(bool visible, float fadeTime);
    public void ShowRadialIndicator(float fill);
    public void ShowTopScreenText(string t);
    public void HideTopScreenText();
    public void ShowFirearmReticle();
    public void HideFirearmReticle();
    public void SetFirearmReticle(float spreadAngle);
}