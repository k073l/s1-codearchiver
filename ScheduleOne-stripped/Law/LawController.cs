using System;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Law;
public class LawController : Singleton<LawController>, IBaseSaveable, ISaveable
{
    public const float DAILY_INTENSITY_DRAIN;
    [Range(1f, 10f)]
    public int LE_Intensity;
    private float internalLawIntensity;
    [Header("Settings")]
    public LawActivitySettings MondaySettings;
    public LawActivitySettings TuesdaySettings;
    public LawActivitySettings WednesdaySettings;
    public LawActivitySettings ThursdaySettings;
    public LawActivitySettings FridaySettings;
    public LawActivitySettings SaturdaySettings;
    public LawActivitySettings SundaySettings;
    [Header("Demo Settings")]
    public float IntensityIncreasePerDay;
    private LawLoader loader;
    public bool OverrideSettings { get; protected set; }
    public LawActivitySettings OverriddenSettings { get; protected set; }
    public LawActivitySettings CurrentSettings { get; protected set; }
    public string SaveFolderName => "Law";
    public string SaveFileName => "Law";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    protected override void Awake();
    public virtual void InitializeSaveable();
    protected override void Start();
    protected override void OnDestroy();
    private void OnLoadComplete();
    private void MinPass();
    private void HourPass();
    private void DayPass();
    public LawActivitySettings GetSettings();
    public LawActivitySettings GetSettings(EDay day);
    public void OverrideSetings(LawActivitySettings settings);
    public void EndOverride();
    public void ChangeInternalIntensity(float change);
    public void SetInternalIntensity(float intensity);
    public virtual string GetSaveString();
    public void Load(LawData data);
}