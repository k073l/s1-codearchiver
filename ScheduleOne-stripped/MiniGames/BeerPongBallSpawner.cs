using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.MiniGames;
public class BeerPongBallSpawner : MonoBehaviour
{
    private const float SpawnCooldown;
    private const float ProximityThreshold;
    [SerializeField]
    private TableTennisBall _ballPrefab;
    private TableTennisBall _lastSpawnedBall;
    private void Awake();
    private void Start();
    private void RefreshSpawn();
    private void SpawnBall();
}