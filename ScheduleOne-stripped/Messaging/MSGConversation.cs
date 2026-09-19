using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.NPCs.Relation;
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
public class MSGConversation
{
    private const int MessageHistory;
    public List<EConversationCategory> Categories;
    private List<Message> _messageHistory;
    private List<MessageChain> _messageChainHistory;
    private List<MessageBubble> _bubbles;
    private List<SendableMessage> _sendables;
    private MessageContactInfo _sender;
    private bool _rollingOut;
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
    protected UISelectable uiSelectable;
    protected UIPanel dialogueScreenUIPanel;
    private bool uiCreated;
    public Action onMessageRendered;
    public Action onLoaded;
    public Action onResponsesShown;
    public Action onConversationOpened;
    public List<Response> currentResponses;
    private List<RectTransform> responseRects;
    public string ContactName => _sender.Name;
    public string ConversationId { get; private set; }
    public bool IsSenderKnown { get; protected set; } = true;
    public bool Read { get; private set; } = true;
    public int Index { get; protected set; }
    public bool IsOpen { get; protected set; }
    public int MessageHistoryCount => _messageHistory.Count;
    public bool EntryVisible { get; protected set; } = true;
    public UISelectable UISelectable => uiSelectable;
    public bool AreResponsesActive => currentResponses.Count > 0;
    public string SaveFolderName => "MessageConversation";
    public string SaveFileName => "MessageConversation";
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    public MSGConversation(MessageContactInfo contact, string conversationId);
    public void SetCategories(List<EConversationCategory> cat);
    public void MoveToTop();
    public bool ShouldReplicate();
    public int GetReplicationByteSize();
    public Sprite GetSenderIcon();
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
    public void Load(MSGConversationData data);
    public void ResetConversation();
    public void SetSliderValue(float value, Color color);
    public Response GetResponse(string label);
    public void ShowResponses(List<Response> _responses, float showResponseDelay = 0f, bool network = true);
    protected void CreateResponseUI(Response r);
    protected void ClearResponseUI();
    public void SetResponseContainerVisible(bool visible);
    public void ResponseChosen(Response r, bool network);
    public void ClearResponses(bool network = false);
    public SendableMessage CreateSendableMessage(string text);
    public void SendPlayerMessage(int sendableIndex, int sentIndex, bool network);
    public void SendPlayerMessage(SendableMessage message, int sentIndex, bool network);
    public void RenderPlayerMessage(SendableMessage sendable);
    private void CheckSendLoop();
    private bool CanSendNewMessage();
}