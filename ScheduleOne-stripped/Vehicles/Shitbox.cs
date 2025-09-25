using System;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Vehicles;
public class Shitbox : LandVehicle
{
    [Serializable]
    public class LoanSharkVisualsData : SaveData
    {
        public bool Enabled;
        public bool NoteVisible;
    }

    public LoanSharkCarVisuals LoanSharkVisuals;
    private bool NetworkInitialize___EarlyScheduleOne_002EVehicles_002EShitboxAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVehicles_002EShitboxAssembly_002DCSharp_002Edll_Excuted;
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}