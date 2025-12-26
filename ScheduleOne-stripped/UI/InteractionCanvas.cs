using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class InteractionCanvas : Singleton<InteractionCanvas>
{
    public const float DISPLAY_SIZE_MULTIPLIER;
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
    public Text IconText;
    public Text MessageText;
    public RectTransform WSLabelContainer;
    public RectTransform BackgroundImage;
    [Header("Prefabs")]
    public GameObject WSLabelPrefab;
    private bool _interactionDisplayEnabledThisFrame;
    private Coroutine _displayScaleLerpRoutine;
    [HideInInspector]
    public List<WorldSpaceLabel> ActiveWSlabels;
    public float displayScale { get; set; } = 1f;

    protected virtual void LateUpdate();
    public void EnableInteractionDisplay(Vector3 pos, Sprite icon, string spriteText, string message, Color messageColor, Color iconColor);
    public void LerpDisplayScale(float endScale);
}