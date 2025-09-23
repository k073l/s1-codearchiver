namespace ScheduleOne.Combat;
public struct ExplosionData
{
    public float DamageRadius;
    public float MaxDamage;
    public float PushForceRadius;
    public float MaxPushForce;
    public bool CheckLoS;
    public static readonly ExplosionData DefaultSmall;
    public ExplosionData(float damageRadius, float maxDamage, float maxPushForce, bool checkLoS);
}