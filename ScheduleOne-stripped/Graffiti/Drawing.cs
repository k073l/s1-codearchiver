using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScheduleOne.Graffiti;
public class Drawing
{
    private class DrawData
    {
        public List<DrawPixels> DrawPixels;
        public void Add(DrawPixels drawPixels);
        public bool IsEmpty();
        public void Clear();
    }

    private class DrawPixels
    {
        public int BottomLeftX;
        public int BottomLeftY;
        public int BlockWidth;
        public Color[] Colors;
        public DrawPixels(int bottomLeftX, int bottomLeftY, int blockWidth, Color[] colors);
    }

    private List<SprayStroke> strokes;
    private Texture2DArray _historyTextureArray;
    private int[] PaintedPixelHistory;
    private int[] _strokeHistory;
    private const int MAX_UNDO_STATES;
    public Action onTextureChanged;
    private int _width { get; set; }
    private int _height { get; set; }
    public int TextureWidth => Mathf.NextPowerOfTwo(_width);
    public int TextureHeight => Mathf.NextPowerOfTwo(_height);
    public Texture2D OutputTexture { get; private set; }
    public int StrokeCount => strokes.Count;
    public int PaintedPixelCount { get; set; }
    public int HistoryIndex { get; private set; } = -1;
    public int HistoryCount { get; private set; }

    public List<SprayStroke> GetStrokes();
    public Drawing(int width, int height, bool initPixels);
    public Drawing GetCopy();
    public void DrawPaintedPixel(PixelData data, bool applyTexture);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color LerpUnclampedFast(Color a, Color b, float t);
    private void ApplyTexture();
    private bool IsCoordinateInBounds(int x, int y);
    public void AddStroke(SprayStroke stroke);
    public void AddStrokes(List<SprayStroke> newStrokes);
    public bool CanUndo();
    public void Undo();
    public void CacheDrawing();
    public void RestoreFromCache();
    public void AddTextureToHistory(bool saveToCache = false);
}