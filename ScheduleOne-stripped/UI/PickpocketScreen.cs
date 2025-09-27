using System.Collections;
using System.Collections.Generic;
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
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Items;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class PickpocketScreen : Singleton<PickpocketScreen>
{
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
    public InputPrompt InputPrompt;
    public RectTransform ActionsContainer;
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
    public void Open(NPC _npc);
    private void Exit(ExitAction action);
    private void Update();
    private void StopArrow();
    public void SetSlotLocked(int index, bool locked);
    private ItemSlotUI GetHoveredSlot();
    private void Fail();
    public void Close();
    private void OpenTutorial();
    public void CloseTutorial();
    private float GetGreenAreaNormalizedPosition(int index);
    private float GetGreenAreaNormalizedWidth(int index);
}