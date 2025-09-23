using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.UI.Relations;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.ContactsApp;
public class ContactsApp : App<ContactsApp>
{
    [Serializable]
    public class RegionUI
    {
        public EMapRegion Region;
        public Button Button;
        public RectTransform Container;
        public RectTransform ConnectionsContainer;
        public List<NPC> npcs { get; set; } = new List<NPC>();
    }

    public EMapRegion SelectedRegion;
    private Dictionary<EMapRegion, RegionUI> RegionDict;
    [Header("References")]
    public PinchableScrollRect ScrollRect;
    public RectTransform CirclesContainer;
    public RectTransform DemoCirclesContainer;
    public RectTransform TutorialCirclesContainer;
    public RectTransform ConnectionsContainer;
    public RectTransform ContentRect;
    public RectTransform SelectionIndicator;
    public ContactsDetailPanel DetailPanel;
    public RegionUI[] RegionUIs;
    public RectTransform RegionSelectionContainer;
    public RectTransform RegionSelectionIndicator;
    public RectTransform InfluenceContainer;
    public Slider InfluenceSlider;
    public Text InfluenceCountLabel;
    public RectTransform UnlockRegionSliderNotch;
    public Text InfluenceText;
    public RectTransform LowerContainer;
    public RectTransform HorizontalScrollbarRectTransform;
    public RectTransform RegionLockedContainer;
    public RectTransform RegionLocked_Rank;
    public RectTransform RegionLocked_CartelInfluence;
    public Text RegionLocked_CartelInfluence_Text;
    public RectTransform RegionLocked_Unavailable;
    [Header("Prefabs")]
    public GameObject ConnectionPrefab;
    private List<RelationCircle> RelationCircles;
    private Coroutine contentMoveRoutine;
    private List<Tuple<NPC, NPC>> connections;
    protected override void Start();
    protected override void Update();
    private RelationCircle GetRelationCircle(string npcID);
    private void CircleClicked(RelationCircle circ);
    private void Select(RelationCircle circ);
    public void SetSelectedRegion(EMapRegion region, bool selectNPC);
    private void ZoomToRect(RectTransform rect);
    private void StopContentMove();
    public override void SetOpen(bool open);
}