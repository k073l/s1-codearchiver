using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
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
    [SerializeField]
    private NakedAppearanceObject[] _maleAppearances;
    [SerializeField]
    private NakedAppearanceObject[] _femaleAppearances;
    [SerializeField]
    private Outfit[] _maleOutfits;
    [SerializeField]
    private Outfit[] _femaleOutfits;
    [SerializeField]
    private Color[] _skinToneOptions;
    [SerializeField]
    private Color[] _hairColorOptions;
    [SerializeField]
    private VODatabase[] _maleVoices;
    [SerializeField]
    private VODatabase[] _femaleVoices;
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
    public NakedAppearanceObject GetAppearanceAtIndex(bool isMale, int index);
    public Outfit GetOutfitAtIndex(bool isMale, int index);
    public VODatabase GetVoiceAtIndex(bool isMale, int index);
}