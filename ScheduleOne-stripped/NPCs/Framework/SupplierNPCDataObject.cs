using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(fileName = "SupplierNPCDataObject", menuName = "ScheduleOne/NPCs/Supplier Data Object", order = -1)]
public class SupplierNPCDataObject : GenericNPCDataObject<SupplierNPCData>
{
    public override void Initialize();
}