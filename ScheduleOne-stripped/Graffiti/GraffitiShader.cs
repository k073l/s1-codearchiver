using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ScheduleOne.Graffiti;
public class GraffitiShader
{
    public struct StrokeData
    {
        public uint2 Start;
        public uint2 End;
        public uint Color;
        public uint Size;
        public static int Stride => 24;
    }

    private int _kernal;
    private ComputeShader _shader;
    private Texture2D _texture;
    private int _width;
    private int _height;
    private List<StrokeData> _strokes;
    private float[] _falloffTable;
    public void Initialise(Texture2D texture, int minStrokeSize, int maxStrokeSize, AnimationCurve falloffCurve);
    public void Draw();
    public void ClearStrokes();
    public void AddStrokes(List<SprayStroke> strokes);
    public void RemoveStrokes(int count);
    private void CreateFalloffTables(int minFalloff, int maxFalloff, AnimationCurve falloffCurve);
}