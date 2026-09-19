using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Cutscenes;
[RequireComponent(typeof(Animation))]
public class Cutscene : MonoBehaviour
{
    [Header("Settings")]
    public string Name;
    public bool UseCinematicBars;
    [Header("Events")]
    public UnityEvent onPlay;
    public UnityEvent onEnd;
    private Animation _animation;
    private ScheduleOne.State.State _state;
    protected CutsceneCamera _activeCameraController;
    public bool IsPlaying { get; private set; }

    protected virtual void Awake();
    private void Start();
    private void OnDestroy();
    private void LateUpdate();
    private void UpdateCamera();
    public virtual void Play();
    public void InvokeEnd();
    protected virtual void End();
    public void SetActiveCameraControl(CutsceneCamera cameraController);
    public void ClearActiveCameraControl(CutsceneCamera cameraController);
    private void DisableActiveCameraControl();
}