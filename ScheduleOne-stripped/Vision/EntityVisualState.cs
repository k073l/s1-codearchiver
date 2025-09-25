using System;

namespace ScheduleOne.Vision;
[Serializable]
public class EntityVisualState
{
    public EVisualState state;
    public string label;
    public Action stateDestroyed;
}