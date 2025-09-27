using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using ScheduleOne.UI.Phone;
using ScheduleOne.UI.Phone.Map;
using ScheduleOne.UI.Phone.Messages;
using UnityEngine;

namespace ScheduleOne.UI;
public class GameplayMenu : Singleton<GameplayMenu>
{
    public enum EGameplayScreen
    {
        Phone,
        Character
    }

    public const float OpenVerticalOffset;
    public const float ClosedVerticalOffset;
    public const float OpenTime;
    public const float SlideTime;
    [Header("References")]
    public Camera OverlayCamera;
    public Light OverlayLight;
    [Header("Settings")]
    public float ContainerOffset_PhoneScreen;
    private Coroutine openCloseRoutine;
    private Coroutine screenChangeRoutine;
    public bool IsOpen { get; protected set; }
    public bool CharacterScreenEnabled => true;
    public EGameplayScreen CurrentScreen { get; protected set; }

    protected override void Start();
    public void Exit(ExitAction exit);
    protected virtual void Update();
    public void SetScreen(EGameplayScreen screen);
    public void SetIsOpen(bool open);
}