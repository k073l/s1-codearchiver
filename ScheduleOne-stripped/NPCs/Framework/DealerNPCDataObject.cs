using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(fileName = "DealerNPCDataObject", menuName = "ScheduleOne/NPCs/Dealer Data Object", order = -1)]
public class DealerNPCDataObject : GenericNPCDataObject<DealerNPCData>
{
    public override void Initialize();
}