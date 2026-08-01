using System;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Health
{
    public float MaxHealth;
    public bool Invincible;
    public bool CanRevive;
    public int DaysToRevive;
    public Health GetCopy();
}