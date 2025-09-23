using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScheduleOne.Graffiti;
public class Drawing
{
    private ushort falloffRadius;
    private float[] falloffTable;
    private List<SprayStroke> strokes;
    public Action onTextureChanged;
    public int Width { get; private set; }
    public int Height { get; private set; }
    public Texture2D OutputTexture { get; private set; }
    public int StrokeCount => strokes.Count;
    public int PaintedPixelCount { get; private set; }

    public List<SprayStroke> GetStrokes();
    public Drawing(int width, int height, ushort falloffRadius, float[] falloffTable, bool initPixels);
    public Drawing GetCopy();
    public void DrawPaintedPixel(PixelData data, bool applyTexture);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color LerpUnclampedFast(Color a, Color b, float t);
    private void ApplyTexture();
    private bool IsCoordinateInBounds(int x, int y);
    public void AddStroke(SprayStroke stroke);
    public void AddStrokes(List<SprayStroke> newStrokes);
}