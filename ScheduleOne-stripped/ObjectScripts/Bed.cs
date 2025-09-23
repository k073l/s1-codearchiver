using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Properties;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class Bed : NetworkBehaviour
{
    public const int MIN_SLEEP_TIME;
    public const float SLEEP_TIME_SCALE;
    [Header("References")]
    [SerializeField]
    protected InteractableObject intObj;
    public EmployeeHome EmployeeStationThing;
    public MeshRenderer BlanketMesh;
    [Header("Materials")]
    public Material DefaultBlanket;
    public Material BotanistBlanket;
    public Material ChemistBlanket;
    public Material PackagerBlanket;
    public Material CleanerBlanket;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EBedAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EBedAssembly_002DCSharp_002Edll_Excuted;
    public Employee AssignedEmployee { get; }

    public override void Awake();
    public void Hovered();
    public void Interacted();
    private bool CanSleep(out string noSleepReason);
    public void UpdateMaterial();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EBed_Assembly_002DCSharp_002Edll();
}