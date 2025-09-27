using FishNet.Object;

namespace ScheduleOne.Vision;
public interface ISightable
{
    NetworkObject NetworkObject { get; }

    VisionEvent HighestProgressionEvent { get; set; }

    EntityVisibility VisibilityComponent { get; }

    bool IsCurrentlySightable();
}