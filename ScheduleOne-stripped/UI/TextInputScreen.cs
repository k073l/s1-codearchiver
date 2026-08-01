using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class TextInputScreen : Singleton<TextInputScreen>
{
    public delegate void OnSubmit(string text);
    public Canvas Canvas;
    public GameObject Container;
    public TextMeshProUGUI HeaderLabel;
    public TMP_InputField InputField;
    public MonoState State;
    private OnSubmit onSubmit;
    public bool IsOpen => ((Behaviour)Canvas).enabled;

    protected override void Awake();
    public void Submit();
    public void Cancel();
    private void Update();
    public void Open(string header, string text, OnSubmit _onSubmit, int maxChars = 10000);
    private void Close(bool submit);
    private void OnClose();
}