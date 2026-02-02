using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.UI;
using ScheduleOne.UI.Phone;
using ScheduleOne.UI.Phone.Messages;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Messaging;
[Serializable]
public class MSGConversation : ISaveable
{
    public const int MAX_MESSAGE_HISTORY;
    public string contactName;
    public NPC sender;
    public List<Message> messageHistory;
    public List<MessageChain> messageChainHistory;
    public List<MessageBubble> bubbles;
    public List<SendableMessage> Sendables;
    public List<EConversationCategory> Categories;
    public RectTransform entry;
    protected RectTransform container;
    protected RectTransform bubbleContainer;
    protected RectTransform scrollRectContainer;
    protected ScrollRect scrollRect;
    protected Text entryPreviewText;
    protected RectTransform unreadDot;
    protected Slider slider;
    protected Image sliderFill;
    protected RectTransform responseContainer;
    protected MessageSenderInterface senderInterface;
    private bool uiCreated;
    public Action onMessageRendered;
    public Action onLoaded;
    public Action onResponsesShown;
    public Action onConversationOpened;
    public List<Response> currentResponses;
    private List<RectTransform> responseRects;
    public bool IsSenderKnown { get; protected set; } = true;
    public bool Read { get; private set; } = true;
    public int index { get; protected set; }
    public bool isOpen { get; protected set; }
    public bool rollingOut { get; protected set; }
    public bool EntryVisible { get; protected set; } = true;
    public bool AreResponsesActive => currentResponses.Count > 0;
    public string SaveFolderName => "MessageConversation";
    public string SaveFileName => "MessageConversation";
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    public MSGConversation(NPC _npc, string _contactName);
    public virtual void InitializeSaveable();
    public void SetCategories(List<EConversationCategory> cat);
    public void MoveToTop();
    public bool ShouldReplicate();
    public int GetReplicationByteSize();
    protected void CreateUI();
    public void EnsureUIExists();
    protected void RefreshPreviewText();
    public void RepositionEntry();
    public void SetIsKnown(bool known);
    public void EntryClicked();
    public void SetOpen(bool open);
    public void DisplayRelationshipInfo();
    protected virtual void RenderMessage(Message m);
    public void SetEntryVisibility(bool v);
    public void SetRead(bool r);
    public void SendMessage(Message message, bool notify = true, bool network = true);
    public void SendMessageChain(MessageChain messages, float initialDelay = 0f, bool notify = true, bool network = true);
    public MSGConversationData GetSaveData();
    public virtual string GetSaveString();
    public virtual void Load(MSGConversationData data);
    public void ResetConversation();
    public void SetSliderValue(float value, Color color);
    public Response GetResponse(string label);
    public void ShowResponses(List<Response> _responses, float showResponseDelay = 0f, bool network = true);
    protected void CreateResponseUI(Response r);
    private void RefreshResponseContainer();
    protected void ClearResponseUI();
    public void SetResponseContainerVisible(bool v);
    public void ResponseChosen(Response r, bool network);
    public void ClearResponses(bool network = false);
    public SendableMessage CreateSendableMessage(string text);
    public void SendPlayerMessage(int sendableIndex, int sentIndex, bool network);
    public void RenderPlayerMessage(SendableMessage sendable);
    private void CheckSendLoop();
    private bool CanSendNewMessage();
}