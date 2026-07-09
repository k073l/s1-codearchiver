using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class Clickable : MonoBehaviour, IGamepadPointerLure
{
    [Header("Clickable: Properties")]
    public bool ClickableEnabled;
    public bool AutoCalculateOffset;
    public bool FlattenZOffset;
    [Header("Clickable: Gamepad")]
    [SerializeField]
    protected GamepadPointerLureData _gamepadLure;
    [SerializeField]
    protected Transform _gamepadLureLocationOverride;
    [Header("Clickable: Events")]
    public UnityEvent<RaycastHit> onClickStart;
    public UnityEvent onClickEnd;
    protected bool _isLureActive;
    public virtual CursorManager.ECursorType HoveredCursor { get; protected set; } = CursorManager.ECursorType.Finger;
    public Vector3 originalHitPoint { get; protected set; } = Vector3.zero;
    public IGamepadPointerLure GamepadLure => this;
    public virtual bool RegisterDefaultLureWhenEmpty => false;
    protected virtual Vector3 LurePositionOffset { get; set; }
    public bool IsHeld { get; protected set; }

    GamepadPointerLureData IGamepadPointerLure.Data => _gamepadLure;

    bool IGamepadPointerLure.IsActive { get; }

    Vector3 IGamepadPointerLure.Position { get; }

    Vector3 IGamepadPointerLure.Offset => LurePositionOffset;

    private void Awake();
    protected virtual void Start();
    public virtual void StartClick(RaycastHit hit);
    public virtual void EndClick();
    public void SetOriginalHitPoint(Vector3 hitPoint);
    protected virtual void OnDestroy();
    void IGamepadPointerLure.SetActive(bool value);
}