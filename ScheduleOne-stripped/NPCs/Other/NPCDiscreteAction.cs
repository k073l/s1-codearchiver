using FishNet;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public abstract class NPCDiscreteAction : MonoBehaviour
{
    public bool IsActive { get; protected set; }

    protected virtual void BeginOnServer();
    protected virtual void BeginOnClient();
    protected virtual void EndOnServer();
    protected virtual void EndOnClient();
    public void Begin();
    public void End();
}