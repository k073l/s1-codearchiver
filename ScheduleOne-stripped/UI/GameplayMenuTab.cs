using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Phone;

namespace ScheduleOne.UI;
public class GameplayMenuTab : UITab
{
    protected override bool CanNavigate(float navDir);
    public bool CanRespondToInput();
}