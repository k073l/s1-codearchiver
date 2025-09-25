namespace ScheduleOne.Persistence.Datas;
public class NPCHealthData : SaveData
{
    public float Health;
    public bool IsDead;
    public int DaysPassedSinceDeath;
    public int HoursSinceAttackedByPlayer;
    public NPCHealthData(float health, bool isDead, int daysPassedSinceDeath, int hoursSinceAttackedByPlayer);
}