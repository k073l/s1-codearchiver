namespace ScheduleOne;
public class ExitAction
{
    private bool used;
    public ExitType Type { get; private set; }
    public bool Used { get; set; }

    public ExitAction(ExitType type);
    public void Use();
}