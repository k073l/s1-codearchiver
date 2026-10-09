using ScheduleOne.AvatarFramework.Animation;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class VomitAuxAction : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject _vomitEffect;
    private AvatarAnimation _anim;
    private NPC _npc;
    private void Awake();
    public void Begin();
    public void End();
}