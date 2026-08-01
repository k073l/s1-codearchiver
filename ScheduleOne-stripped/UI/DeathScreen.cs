using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.Law;
using ScheduleOne.Map;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.State;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class DeathScreen : Singleton<DeathScreen>
{
    [Header("References")]
    public Canvas canvas;
    public RectTransform Container;
    public CanvasGroup group;
    public Button respawnButton;
    public Button loadSaveButton;
    public Animation Anim;
    public AudioSourceController Sound;
    public MonoState State;
    private bool isOpen;
    private bool arrested;
    protected override void Awake();
    private void RespawnClicked();
    private void LoadSaveClicked();
    public void Open();
    private bool CanRespawn();
    private bool CanLoadSave();
    public void Close();
}