using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.Growing;
public class PlantHarvestable : MonoBehaviour, IGamepadPointerLure
{
    public StorableItemDefinition Product;
    public int ProductQuantity;
    [Header("Gamepad")]
    [SerializeField]
    protected GamepadPointerLureData _gamepadLure;
    [SerializeField]
    protected Transform _gamepadLureLocationOverride;
    protected bool _isLureActive;
    public IGamepadPointerLure GamepadLure => this;
    public virtual bool RegisterDefaultLureWhenEmpty => true;

    GamepadPointerLureData IGamepadPointerLure.Data => _gamepadLure;

    bool IGamepadPointerLure.IsActive { get; }

    Vector3 IGamepadPointerLure.Position { get; }

    Vector3 IGamepadPointerLure.Offset { get; }

    private void Awake();
    public virtual void Start();
    private void OnDestroy();
    public virtual void Harvest(bool giveProduct = true);
    void IGamepadPointerLure.SetActive(bool value);
}