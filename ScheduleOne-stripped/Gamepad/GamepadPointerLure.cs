using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Gamepad;
public class GamepadPointerLure : MonoBehaviour, IGamepadPointerLure
{
    [Header("Settings")]
    [SerializeField]
    private GamepadPointerLureData _data;
    [SerializeField]
    private bool _registerDefaultLureWhenEmpty;
    [Header("Development")]
    [SerializeField]
    private bool _isActive;
    public GamepadPointerLureData Data => _data;
    public bool IsActive => _isActive;
    public bool RegisterDefaultLureWhenEmpty => _registerDefaultLureWhenEmpty;
    public Vector3 Position => ((Component)this).transform.position;
    public Vector3 Offset { get; }

    private void Start();
    public void SetActive(bool active);
    private void OnDestroy();
    private void OnDrawGizmos();
}