using System;
using System.Collections;
using UnityEngine;

namespace ScheduleOne.Reporting;
public static class ScreenshotUtil
{
    private const int BixTex;
    private const float TexDimensionMax;
    public static event Action OnPrepareScreenshot;
    public static event Action OnScreenshotDone;
    public static IEnumerator CaptureScreenshot(bool resizeLargeScreenshots, Action<byte[]> onCapturedCallback, Action<string> onErrorCallback);
    private static IEnumerator CaptureScreenshotAsTexture(bool resizeLargeScreenshots, Action<byte[]> onCapturedCallback);
    private static void Scale(Texture2D texture, float scale, FilterMode filterMode = (FilterMode)2, bool updateMipMaps = false);
}