using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.Management;
public interface IUsable
{
    bool IsInUse { get; }

    NetworkObject NPCUserObject { get; set; }

    NetworkObject PlayerUserObject { get; set; }

    void SetPlayerUser(NetworkObject playerObject);
    void SetNPCUser(NetworkObject playerObject);
}