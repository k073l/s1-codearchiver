using ScheduleOne.Audio;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.AvatarFramework.Equipping;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class SprayPaint : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private NPC _npc;
    [SerializeField]
    private AvatarEquippable _sprayPaintPrefab;
    [SerializeField]
    private AvatarAnimation _anim;
    [SerializeField]
    private AudioSourceController _spraySound;
    private AvatarEquippable _sprayPaint;
    private ParticleSystem _sprayEffect;
    private void Awake();
    public void Begin();
    public void End();
    public void SetEffect(bool value, Color colour = default(Color));
}