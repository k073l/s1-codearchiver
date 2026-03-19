namespace ScheduleOne.Combat;
public struct ExplosionData
{
    public float DamageRadius;
    public float MaxDamage;
    public float PushForceRadius;
    public float MaxPushForce;
    public bool CheckLoS;
    public EExplosionType ExplosionType;
    public static readonly ExplosionData DefaultSmall;
    public static readonly ExplosionData LightningStrike;
    public ExplosionData(float damageRadius, float maxDamage, float maxPushForce, bool checkLoS, EExplosionType explosionType = EExplosionType.Default);
}