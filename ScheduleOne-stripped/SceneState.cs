using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne;
public class SceneState : MonoStateMachine
{
    [SerializeField]
    private InGameStateMachine _inGameState;
    public static SceneState Current { get; private set; }
    public static IState ActiveState => Current.PeekRecursive();
    public static IState LastFrameActiveState { get; private set; }
    public InGameStateMachine InGame => _inGameState;

    protected override void Awake();
    private void Update();
    private void OnDestroy();
}