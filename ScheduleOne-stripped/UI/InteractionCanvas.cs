using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class InteractionCanvas : Singleton<InteractionCanvas>
{
    public const float DisplayScaleMultiplier;
    private const float DisplayScale3DBlend;
    [Header("Settings")]
    public Color DefaultMessageColor;
    public Color DefaultIconColor;
    public Color DefaultKeyColor;
    public Color InvalidMessageColor;
    public Color InvalidIconColor;
    public Sprite KeyIcon;
    public Sprite LeftMouseIcon;
    public Sprite CrossIcon;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public Image Icon;
    [SerializeField]
    private TextMeshProUGUI IconText;
    [SerializeField]
    private TextMeshProUGUI MessageText;
    [SerializeField]
    private LayoutElement Layout;
    public RectTransform WSLabelContainer;
    public RectTransform BackgroundImage;
    [Header("Prefabs")]
    public GameObject WSLabelPrefab;
    private bool _interactionDisplayEnabledThisFrame;
    private Coroutine _displayScaleLerpRoutine;
    private InputPromptsDescriptorData _currentDescriptorData;
    private bool _isActive;
    [HideInInspector]
    public List<WorldSpaceLabel> ActiveWSlabels;
    public float DisplayScale { get; set; } = 1f;

    protected override void Start();
    private void Update();
    protected virtual void LateUpdate();
    public void SetActive(bool value);
    public void EnableInteractionDisplay(Vector3 position, string message, Color messageColor, Sprite sprite, Color spriteColor, string spriteText, float spritePixelMultiplier, Vector2 spriteSize, bool enableBackdrop);
    public void LerpDisplayScale(float endScale);
    public void SetIcon(Sprite sprite, Color spriteColor, string spriteText, float spritePixelMultiplier, Vector2 spriteSize, bool enableBackdrop);
    protected override void OnDestroy();
}