using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne.UI;
public class ArrestScreen : Singleton<ArrestScreen>
{
    [Header("References")]
    public Canvas canvas;
    public CanvasGroup group;
    public AudioSourceController Sound;
    public Animation Anim;
    public MonoState State;
    public bool isOpen { get; protected set; }

    protected override void Awake();
    private void Continue();
    public void Open();
    public void Close();
}