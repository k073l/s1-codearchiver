using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public abstract class StationInterface<T> : Singleton<T> where T : Singleton<T>
{
    private const float OpenLerpTime;
    private const float CloseLerpTime;
    [Header("References")]
    [SerializeField]
    protected Canvas _canvas;
    [SerializeField]
    protected RectTransform _container;
    [SerializeField]
    private UIScreen _uiScreen;
    public bool IsOpen { get; private set; }

    protected override void Awake();
    protected override void Start();
    protected virtual void OnOpen(Transform cameraAlignment);
    protected virtual void OnClose();
    protected virtual float GetFoV();
}