using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using AeLa.EasyFeedback;
using AeLa.EasyFeedback.FormElements;
using AeLa.EasyFeedback.Utility;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class FeedbackForm : FeedbackForm
{
    private Coroutine ssCoroutine;
    public CanvasGroup CanvasGroup;
    public Toggle ScreenshotToggle;
    public Toggle SaveFileToggle;
    public TMP_InputField SummaryField;
    public TMP_InputField DescriptionField;
    public RectTransform Cog;
    public TMP_Dropdown CategoryDropdown;
    public override void Awake();
    private void Update();
    public void PrepScreenshot();
    private void OnScreenshotToggle(bool value);
    private void OnSaveFileToggle(bool value);
    public void SetFormData(string title);
    public void SetCategory(string categoryName);
    public override void Submit();
    protected override string GetTextToAppendToTitle();
    private void Clear();
    private IEnumerator ScreenshotAndOpenForm();
}