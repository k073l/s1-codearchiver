using FishNet.Object;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Management;
public interface IUsable
{
    bool IsInUse { get; }

    bool IsUsedByLocalPlayer { get; }

    NetworkObject NPCUserObject { get; set; }

    NetworkObject PlayerUserObject { get; set; }

    string UserName { get; }

    bool IsInUseByNPC(NPC npc);
    void SetPlayerUser(NetworkObject playerObject);
    void SetNPCUser(NetworkObject playerObject);
}