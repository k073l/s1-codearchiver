using UnityEngine;

namespace ScheduleOne.Map;
public class MedicalCentre : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;
    [SerializeField]
    private NPCEnterableBuilding _npcRecoveryRoom;
    public Transform RespawnPoint => _respawnPoint;
    public NPCEnterableBuilding NPCRecoveryRoom => _npcRecoveryRoom;

    private void Awake();
}