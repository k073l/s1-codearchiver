namespace ScheduleOne.DevUtilities;
public class ExitAction
{
    public ExitType exitType;
    private bool used;
    public bool Used { get; set; }

    public void Use();
}