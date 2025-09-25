using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Graffiti;
[Serializable]
public class SprayStroke
{
    public const int MIN_STROKE_LENGTH;
    public const int ANGLE_THRESHOLD_DEG;
    public const float MAX_STROKE_DEVIATION;
    public const int FORWARD_SAMPLE_COUNT;
    public UShort2 Start;
    public UShort2 End;
    public ESprayColor Color;
    public SprayStroke(UShort2 start, UShort2 end, ESprayColor color);
    public SprayStroke();
    public List<PixelData> GetPixelsFromStroke();
    public static List<SprayStroke> GetStrokesFromPixels(List<UShort2> coords, ESprayColor color, SpraySurface surface);
}