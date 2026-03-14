using FishNet;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Property;
public class MotelRoom : Property
{
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002EMotelRoomAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002EMotelRoomAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void UpdateVariables();
    public override bool CanDeliverToProperty();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}