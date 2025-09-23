using System.Collections.Generic;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Map;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class GoonPool : MonoBehaviour
{
    public const float MALE_CHANCE;
    [Header("References")]
    [SerializeField]
    private CartelGoon[] goons;
    [SerializeField]
    private NPCEnterableBuilding[] exitBuildings;
    [Header("Appearance Settings")]
    public AvatarSettings[] MaleBaseAppearances;
    public AvatarSettings[] FemaleBaseAppearances;
    public AvatarSettings[] MaleClothing;
    public AvatarSettings[] FemaleClothing;
    public VODatabase[] MaleVoices;
    public VODatabase[] FemaleVoices;
    public Color[] SkinTones;
    public Color[] HairColors;
    private List<CartelGoon> spawnedGoons;
    private List<CartelGoon> unspawnedGoons;
    public int UnspawnedGoonCount => unspawnedGoons.Count;

    protected virtual void Awake();
    private void Update();
    public List<CartelGoon> SpawnMultipleGoons(Vector3 spawnPoint, int requestedAmount, bool setAsGoonMates = true);
    public CartelGoonAppearance GetRandomAppearance();
    public CartelGoon SpawnGoon(Vector3 spawnPoint);
    public void ReturnToPool(CartelGoon goon);
    public NPCEnterableBuilding GetNearestExitBuilding(Vector3 position);
}