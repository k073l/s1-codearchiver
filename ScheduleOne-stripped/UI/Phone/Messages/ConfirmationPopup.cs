using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Messaging;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages;
public class ConfirmationPopup : MonoBehaviour
{
    public enum EResponse
    {
        Confirm,
        Cancel
    }

    [Header("References")]
    public GameObject Container;
    public Text TitleLabel;
    public Text MessageLabel;
    public Button ConfirmButton;
    public Button CancelButton;
    private MSGConversation conversation;
    private Action<EResponse> responseCallback;
    public bool IsOpen { get; private set; }

    private void Start();
    public void Exit(ExitAction action);
    public void Open(string title, string message, MSGConversation conv, Action<EResponse> callback);
    public void Close(EResponse outcome);
    private void Confirm();
    private void Cancel();
}