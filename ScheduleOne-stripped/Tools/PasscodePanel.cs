using System.Collections;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Tools;
public class PasscodePanel : NetworkBehaviour
{
    public const int PasscodeLength;
    [Header("Settings")]
    public string CorrectPasscode;
    [Header("References")]
    public InteractableObject[] Buttons;
    public TextMeshPro CodeLabel;
    public UnityEvent onButtonPressed;
    public UnityEvent onCorrect;
    public UnityEvent onIncorrect;
    private string enteredPasscode;
    private bool NetworkInitialize___EarlyScheduleOne_002ETools_002EPasscodePanelAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ETools_002EPasscodePanelAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void OnSpawnServer(NetworkConnection connection);
    private void OnButtonPressed(int number);
    [ServerRpc(RequireOwnership = false)]
    private void OnButtonPressed_Server(int number);
    [ObserversRpc]
    private void RegisterButtonPress(int number);
    public void SetIsUsable(bool isUsable);
    [ObserversRpc]
    [TargetRpc]
    private void SetEnteredPasscode(NetworkConnection conn, string passcode);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_OnButtonPressed_Server_3316948804(int number);
    private void RpcLogic___OnButtonPressed_Server_3316948804(int number);
    private void RpcReader___Server_OnButtonPressed_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RegisterButtonPress_3316948804(int number);
    private void RpcLogic___RegisterButtonPress_3316948804(int number);
    private void RpcReader___Observers_RegisterButtonPress_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetEnteredPasscode_2971853958(NetworkConnection conn, string passcode);
    private void RpcLogic___SetEnteredPasscode_2971853958(NetworkConnection conn, string passcode);
    private void RpcReader___Observers_SetEnteredPasscode_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetEnteredPasscode_2971853958(NetworkConnection conn, string passcode);
    private void RpcReader___Target_SetEnteredPasscode_2971853958(PooledReader PooledReader0, Channel channel);
    private void Awake_UserLogic_ScheduleOne_002ETools_002EPasscodePanel_Assembly_002DCSharp_002Edll();
}