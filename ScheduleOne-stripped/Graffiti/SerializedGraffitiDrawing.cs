using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Graffiti;
[CreateAssetMenu(fileName = "Graffiti Drawing", menuName = "Serialized Graffiti Drawing", order = 1)]
public class SerializedGraffitiDrawing : ScriptableObject
{
    [field: SerializeField]
    public string DrawingName { get; private set; } = "New Graffiti Drawing";

    [field: SerializeField]
    public int Width { get; private set; }

    [field: SerializeField]
    public int Height { get; private set; }

    [field: SerializeField]
    public List<SprayStroke> Strokes { get; private set; } = new List<SprayStroke>();

    public void SetDrawingName(string name);
    public void SetStrokes(List<SprayStroke> strokes);
    private void RecalculateSize();
}