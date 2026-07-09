using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne.UI;
public class UIScreenMonoState : MonoState
{
    [Header("Screen")]
    [SerializeField]
    private UIScreen _screen;
    [SerializeField]
    private bool _attachToPlayerInventory;
    protected override void Awake();
    public override void OnActivate();
    public override void OnDeactivate();
}