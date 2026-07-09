using System;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class TaskManager : Singleton<TaskManager>
{
    [SerializeField]
    private AudioSourceController TaskCompleteSound;
    public bool IsTaskActive => CurrentTask != null;
    public Task CurrentTask { get; private set; }
    public float TimeOnLastTaskEnd { get; private set; } = float.MinValue;

    public event Action<Task> OnTaskStarted;
    protected override void Start();
    protected virtual void Update();
    private void Exit(ExitAction action);
    protected virtual void LateUpdate();
    protected virtual void FixedUpdate();
    public void PlayTaskCompleteSound();
    public void StartTask(Task task);
    public void EndTask();
}