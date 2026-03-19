using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Audio;
public class PursuitMusicTrack : MusicTrack
{
    private const float OutOfSightTimeToDipMusic;
    private const float MinMusicVolume;
    private const float MusicChangeRate_Down;
    private const float MusicChangeRate_Up;
    [SerializeField]
    private PlayerCrimeData.EPursuitLevel _pursuitLevelToActivate;
    protected virtual void Start();
    private void OnLoadComplete();
    private void RegisterEvent();
    protected override void Update();
    private void PursuitLevelChange(PlayerCrimeData.EPursuitLevel oldLevel, PlayerCrimeData.EPursuitLevel newLevel);
    private float GetNewVolume();
}