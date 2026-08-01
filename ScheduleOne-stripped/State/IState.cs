namespace ScheduleOne.State;
public interface IState
{
    public enum EFlag
    {
        CanToggleClipboard,
        AllowPlayerMovement,
        CanDismissHint,
        HideWorldspaceDialogue
    }

    string name { get; }

    bool IsActive { get; }

    bool IsAcceptingInput { get; }

    StateProperties Properties { get; }

    EFlag[] Flags { get; }

    void OnActivate();
    void OnDeactivate();
    void NotifyAddedToStack();
    void NotifyRemovedFromStack();
    void NotifyBecomeTopSibling();
    void NotifyNoLongerTopSibling();
    bool ContainsFlag(EFlag flag);
}