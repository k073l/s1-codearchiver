using UnityEngine;

namespace ScheduleOne.UI.Input;
public class InputPromptReference
{
    public string Id;
    public EInputPromptPosition PositionCategory;
    public int CanvasSortingOrder;
    public Vector3 CustomPosition;
    public string DisplayTextOverride;
    public InputPromptReference(string id, EInputPromptPosition positionCategory, string displayTextOverride, Vector3 customPosition = default(Vector3), int canvasSortingOrder = 1);
}