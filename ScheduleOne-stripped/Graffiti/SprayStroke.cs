using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ScheduleOne.Graffiti;
[Serializable]
public class SprayStroke
{
    public const int MinStrokeLength;
    public const int AngleThreshold_Degrees;
    public const float MaxStrokeDeviation;
    public const int ForwardSampleCount;
    public const byte StrokeSize_LegacyDefault;
    public const byte StrokeSize_Small;
    public const byte StrokeSize_Medium;
    public const byte StrokeSize_Large;
    public const byte StrokeSize_ExtraLarge;
    public static readonly byte[] StrokeSizePresets;
    public const byte StrokeSize_Min;
    public const byte StrokeSize_Max;
    public UShort2 Start;
    public UShort2 End;
    public ESprayColor Color;
    public byte StrokeSize;
    public SprayStroke(UShort2 start, UShort2 end, ESprayColor color, byte strokeSize);
    public SprayStroke GetCopy();
    public SprayStroke();
    public List<PixelData> GetPixelsFromStroke();
    public static List<SprayStroke> GetStrokesFromPixels(List<UShort2> coords, ESprayColor color, byte strokeSize, SpraySurface surface);
    public void Serialize(BinaryWriter writer);
    public static SprayStroke Deserialize(BinaryReader reader);
    public static List<SprayStroke> CopyAndShiftStrokes(List<SprayStroke> strokes, UShort2 shift);
    public static void GetBounds(List<SprayStroke> strokes, out UShort2 min, out UShort2 max);
}