using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Cutscenes;
public class CutsceneManager : Singleton<CutsceneManager>
{
    [Header("References")]
    [SerializeField]
    private GameObject _cinematicBars;
    private Dictionary<string, Cutscene> _cutscenes;
    private Cutscene _activeCutscene;
    public event Action<Cutscene> OnCutsceneStarted;
    public event Action<Cutscene> OnCutsceneEnded;
    public void Play(string name);
    public void Play(Cutscene cutscene);
    private void OnActiveCutsceneEnded();
    public void RegisterCutscene(Cutscene cutscene);
    public void UnregisterCutscene(Cutscene cutscene);
    public void SetCinematicBars(bool active);
}