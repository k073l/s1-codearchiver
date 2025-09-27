using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Phone;
using ScheduleOne.UI.Phone.Map;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Quests;
[Serializable]
public class Quest : MonoBehaviour, IGUIDRegisterable, ISaveable
{
    public const int MAX_HUD_ENTRY_LABELS;
    public const int CriticalExpiryThreshold;
    public static List<Quest> Quests;
    public static Quest HoveredQuest;
    public static List<Quest> ActiveQuests;
    [Header("Basic Settings")]
    [SerializeField]
    protected string title;
    public string Subtitle;
    public Action onSubtitleChanged;
    [TextArea(3, 10)]
    public string Description;
    public string StaticGUID;
    public bool TrackOnBegin;
    public EExpiryVisibility ExpiryVisibility;
    public bool AutoCompleteOnAllEntriesComplete;
    public bool PlayQuestCompleteSound;
    public int CompletionXP;
    [Header("Entries")]
    public bool AutoStartFirstEntry;
    public List<QuestEntry> Entries;
    [Header("UI")]
    public RectTransform IconPrefab;
    [Header("PoI Settings")]
    public GameObject PoIPrefab;
    [Header("Events")]
    public UnityEvent onQuestBegin;
    public UnityEvent<EQuestState> onQuestEnd;
    public UnityEvent onActiveState;
    public UnityEvent<bool> onTrackChange;
    public UnityEvent onComplete;
    public UnityEvent onInitialComplete;
    [Header("Reminders")]
    public bool ShouldSendExpiryReminder;
    public bool ShouldSendExpiredNotification;
    protected RectTransform journalEntry;
    protected RectTransform entryTitleRect;
    protected RectTransform trackedRect;
    protected Text entryTimeLabel;
    protected Image criticalTimeBackground;
    protected RectTransform detailPanel;
    public Action onHudUICreated;
    private bool expiryReminderSent;
    private CompassManager.Element compassElement;
    protected bool autoInitialize;
    public EQuestState State { get; protected set; }
    public Guid GUID { get; protected set; }
    public bool IsTracked { get; protected set; }
    public int ActiveEntryCount => Entries.Count(default);
    public string Title => GetQuestTitle();
    public bool Expires { get; protected set; }
    public GameDateTime Expiry { get; protected set; }
    public bool hudUIExists => (Object)(object)hudUI != (Object)null;
    public QuestHUDUI hudUI { get; private set; }
    public string SaveFolderName => "Quest_" + GUID.ToString().Substring(0, 6);
    public string SaveFileName => "Quest_" + GUID.ToString().Substring(0, 6);
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    protected virtual void Awake();
    protected virtual void Start();
    public virtual void InitializeQuest(string title, string description, QuestEntryData[] entries, string guid);
    public virtual void InitializeSaveable();
    public void ConfigureExpiry(bool expires, GameDateTime expiry);
    public virtual void Begin(bool network = true);
    public virtual void Complete(bool network = true);
    public virtual void Fail(bool network = true);
    public virtual void Expire(bool network = true);
    public virtual void Cancel(bool network = true);
    public virtual void End();
    public virtual void SetQuestState(EQuestState state, bool network = true);
    protected virtual bool ShouldShowJournalEntry();
    public virtual void SetQuestEntryState(int entryIndex, EQuestState state, bool network = true);
    protected virtual void MinPass();
    protected virtual void CheckExpiry();
    private void CheckAutoComplete();
    protected virtual bool CanExpire();
    protected virtual void SendExpiryReminder();
    protected virtual void SendExpiredNotification();
    public void SetGUID(Guid guid);
    public void SetSubtitle(string subtitle);
    public virtual void SetIsTracked(bool tracked);
    public virtual void SetupJournalEntry();
    private void DestroyJournalEntry();
    private void JournalEntryClicked();
    private void JournalEntryHoverStart();
    public int GetMinsUntilExpiry();
    public string GetExpiryText();
    public virtual QuestHUDUI SetupHudUI();
    public void UpdateHUDUI();
    public void BopHUDUI();
    public virtual string GetQuestTitle();
    public QuestEntry GetFirstActiveEntry();
    private void DestroyHudUI();
    public virtual RectTransform CreateDetailDisplay(RectTransform parent);
    public void DestroyDetailDisplay();
    public virtual bool ShouldSave();
    public virtual SaveData GetSaveData();
    public string GetSaveString();
    public virtual void Load(QuestData data);
    public static Quest GetQuest(string questName);
}