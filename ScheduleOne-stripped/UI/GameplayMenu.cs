using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Skating;
using ScheduleOne.State;
using ScheduleOne.UI.Items;
using ScheduleOne.UI.Phone;
using ScheduleOne.UI.Phone.Map;
using ScheduleOne.UI.Phone.Messages;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public MonoStateMachine State;
    [Header("Settings")]
    public float ContainerOffset_PhoneScreen;
    [Header("Input")]
    [SerializeField]
    private InputActionReference _toggleAction;
    [SerializeField]
    private InputActionReference _mapShortcutAction;
    [SerializeField]
    private InputActionReference _journalShortcutAction;
    [SerializeField]
    private InputActionReference _messagesShortcutAction;
    private Coroutine openCloseRoutine;
    private Coroutine screenChangeRoutine;
    public bool IsOpen { get; protected set; }
    public bool CharacterScreenEnabled => true;
    public EGameplayScreen CurrentScreen { get; protected set; }

    protected override void Awake();
    protected override void Start();
    public void Exit(ExitAction exit);
    protected virtual void Update();
    private bool AcceptInputFromCurrentState();
    public void SetScreen(EGameplayScreen screen);
    public void Open();
    public void Close();
    private void OnOpen();
    private void OnClose();
    private IEnumerator SetIsOpenRoutine(bool open);
}