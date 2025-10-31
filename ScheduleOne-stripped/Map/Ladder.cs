using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Doors;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.Map;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ladder : MonoBehaviour
{
    public const float NPCClimbOffset;
    public const float LadderMountDismountTimeMultiplier;
    public const float LadderClimbTimeMultiplier;
    public const float NPCClimbSoundInterval;
    public const float PlayerClimbSoundLengthInterval;
    [Header("References")]
    public OffMeshLink OffMeshLink;
    public AudioSourceController ClimbSound;
    public SewerDoorController LinkedManholeCover;
    private BoxCollider boxCollider;
    private float timeOnLastClimbSound;
    public Transform LadderTransform => ((Component)boxCollider).transform;
    public Vector2 LadderSize => new Vector2(boxCollider.size.x * ((Component)this).transform.localScale.x, boxCollider.size.y * ((Component)this).transform.localScale.y);
    public Vector3 BottomCenter => LadderTransform.position + LadderTransform.right * LadderSize.x * 0.5f;
    public Vector3 TopCenter => LadderTransform.position + LadderTransform.right * LadderSize.x * 0.5f + LadderTransform.up * LadderSize.y;

    private void Awake();
    private void OnTriggerEnter(Collider other);
    private void OnTriggerExit(Collider other);
    private void OnDrawGizmos();
    public Vector2 ProjectOnLadderSurface(Vector3 position);
    public Vector2 NormalizeProjectedPosition(Vector2 projectedPosition);
    public void PlayClimbSound(Vector3 position);
}