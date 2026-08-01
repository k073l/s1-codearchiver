using ScheduleOne.Persistence;

namespace ScheduleOne.UI.MainMenu;
public class NewGameScreen : MenuScreen
{
    public ConfirmOverwriteScreen ConfirmOverwriteScreen;
    public SetupScreen SetupScreen;
    public void SlotSelected(int slotIndex);
}