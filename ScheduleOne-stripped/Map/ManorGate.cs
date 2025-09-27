using EasyButtons;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Map;
public class ManorGate : Gate
{
    [Header("References")]
    public InteractableObject IntercomInt;
    public Light IntercomLight;
    public VehicleDetector ExteriorVehicleDetector;
    public PlayerDetector ExteriorPlayerDetector;
    public VehicleDetector InteriorVehicleDetector;
    public PlayerDetector InteriorPlayerDetector;
    private bool intercomActive;
    private bool NetworkInitialize___EarlyScheduleOne_002EMap_002EManorGateAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMap_002EManorGateAssembly_002DCSharp_002Edll_Excuted;
    protected virtual void Start();
    private void UpdateDetection();
    public void IntercomBuzzed();
    public void SetEnterable(bool enterable);
    [Button]
    public void ActivateIntercom();
    public void SetIntercomActive(bool active);
    private void UpdateIntercom();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}