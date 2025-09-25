using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Skating;
public class Skateboard_Equippable : Equippable_Viewmodel
{
    public const float ModelLerpSpeed;
    public const float SurfaceSampleDistance;
    public const float SurfaceSampleRayLength;
    public const float BoardSpawnUpwardsShift;
    public const float BoardSpawnAngleLimit;
    public const float MountTime;
    public const float BoardMomentumTransfer;
    public const float DismountAngle;
    public Skateboard SkateboardPrefab;
    public bool blockDismount;
    [Header("References")]
    public Transform ModelContainer;
    public Transform ModelPosition_Raised;
    public Transform ModelPosition_Lowered;
    private float mountTime;
    public bool IsRiding { get; private set; }
    public Skateboard ActiveSkateboard { get; private set; }

    public override void Equip(ItemInstance item);
    private void Exit(ExitAction action);
    protected override void Update();
    private void UpdateModel();
    public override void Unequip();
    public void Mount();
    public void Dismount();
    private bool CanMountHere();
    private Pose GetSkateboardSpawnPose();
}