using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScheduleOne.UI.Multiplayer;
public class LobbyInterface : Singleton<LobbyInterface>
{
    [Header("References")]
    public RectTransform Container;
    public TextMeshProUGUI LobbyTitle;
    public RectTransform[] PlayerSlots;
    public Button InviteButton;
    public Button LeaveButton;
    public GameObject InviteHint;
    public UIPanel Panel;
    private UIScreen AttachedScreen;
    private Lobby Lobby => Singleton<Lobby>.Instance;

    protected override void Start();
    protected override void OnDestroy();
    private void LateUpdate();
    public void SetVisible(bool visible);
    public void LeaveClicked();
    public void InviteClicked();
    private void DisplayPlayer(int index, string playerID);
    private void ClearPlayer(int index);
    private void UpdateUI();
    private void UpdateButtons();
    private void UpdatePlayers();
    public void AttachToScreen(UIScreen screen);
    public void DetachFromScreen();
}