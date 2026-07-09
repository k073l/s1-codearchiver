namespace ScheduleOne.UI.MainMenu;
public class ConfirmOverwriteScreen : MenuScreen
{
    public SetupScreen SetupScreen;
    private int slotIndex;
    public void Initialize(int index);
    public void Confirm();
}