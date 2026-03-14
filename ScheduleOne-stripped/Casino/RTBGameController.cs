using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Casino.UI;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Casino;
public class RTBGameController : CasinoGameController
{
    public enum EStage
    {
        WaitingForPlayers,
        RedOrBlack,
        HigherOrLower,
        InsideOrOutside,
        Suit
    }

    public const int BET_MINIMUM;
    public const int BET_MAXIMUM;
    public const float ANSWER_MAX_TIME;
    [Header("References")]
    public Transform PlayCameraTransform;
    public Transform FocusedCameraTransform;
    public PlayingCard[] Cards;
    public Transform[] CardDefaultPositions;
    public Transform ActiveCardPosition;
    public Transform[] DockedCardPositions;
    public Action<EStage> onStageChange;
    public Action<string, string[]> onQuestionReady;
    public Action onQuestionDone;
    public Action onLocalPlayerCorrect;
    public Action onLocalPlayerIncorrect;
    public Action onLocalPlayerBetChange;
    public Action onLocalPlayerExitRound;
    private List<Player> playersInCurrentRound;
    private List<PlayingCard.CardData> cardsInDeck;
    private List<PlayingCard.CardData> drawnCards;
    private bool NetworkInitialize___EarlyScheduleOne_002ECasino_002ERTBGameControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECasino_002ERTBGameControllerAssembly_002DCSharp_002Edll_Excuted;
    public EStage CurrentStage { get; private set; }
    public bool IsQuestionActive { get; private set; }
    public float LocalPlayerBet { get; private set; } = 10f;
    public float LocalPlayerBetMultiplier { get; private set; } = 1f;
    public float MultipliedLocalPlayerBet => LocalPlayerBet * LocalPlayerBetMultiplier;
    public float RemainingAnswerTime { get; private set; } = 6f;
    public bool IsLocalPlayerInCurrentRound => playersInCurrentRound.Contains(Player.Local);

    public override void Awake();
    protected override void Open();
    protected override void Close();
    protected override void Exit(ExitAction action);
    [ObserversRpc(RunLocally = true)]
    private void SetStage(EStage stage);
    private void RunRound(EStage stage);
    [ObserversRpc(RunLocally = true)]
    private void SetBetMultiplier(float multiplier);
    [ObserversRpc(RunLocally = true)]
    private void EndGame();
    public void RemoveLocalPlayerFromGame(bool payout, float cameraDelay = 0f);
    private bool IsCurrentRoundEmpty();
    private float GetAnswerIndex(EStage stage, PlayingCard.CardData card);
    [ObserversRpc(RunLocally = true)]
    private void NotifyAnswer(float answerIndex);
    [ObserversRpc(RunLocally = true)]
    private void QuestionDone();
    private void GetQuestionsAndAnswers(EStage stage, out string question, out string[] answers);
    private void ResetCards();
    [ObserversRpc(RunLocally = true)]
    private void AddPlayerToCurrentRound(NetworkObject player);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void RequestRemovePlayerFromCurrentRound(NetworkObject player);
    [ObserversRpc(RunLocally = true)]
    private void RemovePlayerFromCurrentRound(NetworkObject player);
    private PlayingCard.CardData PullCardFromDeck();
    public void SetLocalPlayerBet(float bet);
    public bool AreAllPlayersReady();
    public int GetPlayersReadyCount();
    public void SetLocalPlayerAnswer(float answer);
    public int GetAnsweredPlayersCount();
    public void ToggleLocalPlayerReady();
    [ObserversRpc(RunLocally = true)]
    private void TryNextStage();
    private int GetCardNumberValue(PlayingCard.CardData card);
    public static float GetNetBetMultiplier(EStage stage);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetStage_2502303021(EStage stage);
    private void RpcLogic___SetStage_2502303021(EStage stage);
    private void RpcReader___Observers_SetStage_2502303021(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetBetMultiplier_431000436(float multiplier);
    private void RpcLogic___SetBetMultiplier_431000436(float multiplier);
    private void RpcReader___Observers_SetBetMultiplier_431000436(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_EndGame_2166136261();
    private void RpcLogic___EndGame_2166136261();
    private void RpcReader___Observers_EndGame_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_NotifyAnswer_431000436(float answerIndex);
    private void RpcLogic___NotifyAnswer_431000436(float answerIndex);
    private void RpcReader___Observers_NotifyAnswer_431000436(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_QuestionDone_2166136261();
    private void RpcLogic___QuestionDone_2166136261();
    private void RpcReader___Observers_QuestionDone_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_AddPlayerToCurrentRound_3323014238(NetworkObject player);
    private void RpcLogic___AddPlayerToCurrentRound_3323014238(NetworkObject player);
    private void RpcReader___Observers_AddPlayerToCurrentRound_3323014238(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_RequestRemovePlayerFromCurrentRound_3323014238(NetworkObject player);
    private void RpcLogic___RequestRemovePlayerFromCurrentRound_3323014238(NetworkObject player);
    private void RpcReader___Server_RequestRemovePlayerFromCurrentRound_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RemovePlayerFromCurrentRound_3323014238(NetworkObject player);
    private void RpcLogic___RemovePlayerFromCurrentRound_3323014238(NetworkObject player);
    private void RpcReader___Observers_RemovePlayerFromCurrentRound_3323014238(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_TryNextStage_2166136261();
    private void RpcLogic___TryNextStage_2166136261();
    private void RpcReader___Observers_TryNextStage_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ECasino_002ERTBGameController_Assembly_002DCSharp_002Edll();
}