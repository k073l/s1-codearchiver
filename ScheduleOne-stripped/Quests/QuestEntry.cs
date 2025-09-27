using System;
using System.Linq;
using FishNet.Serializing.Helping;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.UI;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Phone;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Quests;
[Serializable]
public class QuestEntry : MonoBehaviour
{
    [Header("Naming")]
    [SerializeField]
    protected string EntryTitle;
    [SerializeField]
    protected EQuestState state;
    [Header("Settings")]
    public bool AutoComplete;
    public Conditions AutoCompleteConditions;
    public bool CompleteParentQuest;
    public string EntryAddedIn;
    [Header("PoI Settings")]
    public bool AutoCreatePoI;
    public Transform PoILocation;
    public bool AutoUpdatePoILocation;
    public POI PoI;
    public UnityEvent onStart;
    public UnityEvent onEnd;
    public UnityEvent onComplete;
    public UnityEvent onInitialComplete;
    private CompassManager.Element compassElement;
    private QuestEntryHUDUI entryUI;
    private RectTransform PoIIcon;
    [CodegenExclude]
    [field: NonSerialized]
    public Quest ParentQuest { get; private set; }

    [CodegenExclude]
    public string Title => EntryTitle;

    [CodegenExclude]
    public EQuestState State => state;

    protected virtual void Awake();
    protected virtual void Start();
    private void OnValidate();
    public virtual void MinPass();
    public void SetData(QuestEntryData data);
    public void Begin();
    public void Complete();
    public void SetActive(bool network = true);
    public virtual void SetState(EQuestState newState, bool network = true);
    protected virtual bool ShouldShowPoI();
    protected virtual void UpdatePoI();
    public void SetPoILocation(Vector3 location);
    public void CreatePoI();
    public void DestroyPoI();
    public void CreateCompassElement();
    public void UpdateCompassElement();
    public QuestEntryData GetSaveData();
    private void UpdateName();
    private void EvaluateConditions();
    public void SetEntryTitle(string newTitle);
    protected virtual void CreateEntryUI();
    public virtual void UpdateEntryUI();
}