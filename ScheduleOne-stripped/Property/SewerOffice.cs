using System.IO;
using FishNet;
using UnityEngine;

namespace ScheduleOne.Property;
public class SewerOffice : Property
{
    private const string DefaultSaveFilePath;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002ESewerOfficeAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002ESewerOfficeAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public void OnPasscodeCorrect();
    public override bool ShouldSave();
    public string GetDefaultSaveFileFullPath();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EProperty_002ESewerOffice_Assembly_002DCSharp_002Edll();
}